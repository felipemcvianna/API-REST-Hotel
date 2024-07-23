using HotelApi.Context.DTOs;
using HotelApi.Context.Hospedes.Models;
using HotelApi.Context.Quarto.Models.Enums;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Context.Quarto.Services;

public class ServicesQuarto
{
    private readonly HotelDbContext _context;

    public ServicesQuarto(HotelDbContext context)
    {
        _context = context;
    }

    public async Task<List<Models.Quarto>> GetAll()
    {
        return await _context.Quartos.ToListAsync();
    }

    public async Task<Models.Quarto> GetById(int id)
    {
        var quarto = await _context.Quartos
            .Include(x => x.Hospedes)
            .Include(r => r.Reserva)
            .FirstOrDefaultAsync(x => x.Id == id);

        return quarto != null ? quarto : throw new Exception("O quarto está vazio");
    }

    public async Task InsertQuarto(QuartoDTO quartoDto)
    {
        if (quartoDto == null)
            throw new Exception("O objeto quarto não pode ser vazio");
        var quarto = new Models.Quarto()
        {
            Numero = quartoDto.Numero,
            Vagas = quartoDto.Vagas
        };
        await _context.Quartos.AddAsync(quarto);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, QuartoDTO quartoDto)
    {
        if (quartoDto == null)
            throw new Exception("Quarto vazio");

        var quartoAntigo = await _context.Quartos.FirstOrDefaultAsync(x => x.Id == id);
        if (quartoAntigo == null)
            throw new Exception("Quarto não encontrado");

        quartoAntigo.Numero = quartoDto.Numero;
        quartoAntigo.Status = quartoDto.Status;

        _context.Update(quartoAntigo);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var quartoARemover = await _context.Quartos.FirstOrDefaultAsync(x => x.Id == id);
        if (quartoARemover == null)
            throw new Exception("Quarto não encontrado");
        _context.Quartos.Remove(quartoARemover);
        await _context.SaveChangesAsync();
    }

    private async Task PreencherVaga(int id, Hospede hospede)
    {
        var quarto = await GetById(id);
        await AtualizarStatusDisponibilidade(quarto.Id);
        quarto.SalvarVagas = quarto.Vagas;
        if (quarto.Status == Status.Indisponivel)
            throw new Exception($"O quarto de numero {quarto.Numero} não está disponivel");
        if (quarto.Vagas <= 0)
            throw new InvalidOperationException("Não há vagas");
        quarto.Hospedes.Add(hospede);
        quarto.Vagas -= 1;
    }

    public async Task PreencherVagasQuarto(int id)
    {
        var quarto = await GetById(id);
        if (quarto.Reserva == null) throw new ArgumentNullException(nameof(Reserva), "A reserva está vazia");
        foreach (var hospedes in quarto.Reserva.Hospedes)
        {
            await PreencherVaga(id, hospedes);
        }

        quarto.Status = Status.Indisponivel;
    }

    public async Task EsvaziarQuarto(int id)
    {
        var quarto = await GetById(id);

        if (quarto.Hospedes.Count > 0)
        {
            quarto.Hospedes.Clear();
            quarto.Vagas += quarto.SalvarVagas;
            quarto.Status = Status.Disponivel;
        }
        await _context.SaveChangesAsync();
    }

    private async Task AtualizarStatusDisponibilidade(int id)
    {
        var quarto = await GetById(id);
        if (quarto.Hospedes.Count() > quarto.Vagas)
        {
            throw new InvalidOperationException("O quarto não suporta tantos hospedes");
        }

        if (quarto.Reserva == null)
            quarto.Status = Status.Disponivel;
    }
}