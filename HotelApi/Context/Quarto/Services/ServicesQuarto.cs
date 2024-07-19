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
        var quarto = await _context.Quartos.FirstOrDefaultAsync(x => x.Id == id);
        return quarto != null ? quarto : throw new Exception("O quarto está vazio");
    }

    public async Task InsertQuarto(Models.Quarto? quarto)
    {
        if (quarto == null)
            throw new Exception("O objeto quarto não pode ser vazio");
        await _context.Quartos.AddAsync(quarto);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Models.Quarto? quarto)
    {
        if (quarto == null)
            throw new Exception("Quarto vazio");

        var quartoAntigo = await _context.Quartos.FirstOrDefaultAsync(x => x.Id == quarto.Id);
        if (quartoAntigo == null)
            throw new Exception("Quarto não encontrado");

        quartoAntigo.Numero = quarto.Numero;
        quartoAntigo.Status = quarto.Status;

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
}