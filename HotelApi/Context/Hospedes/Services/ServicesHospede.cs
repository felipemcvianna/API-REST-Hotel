using HotelApi.Context.Clientes.Models;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Context.Clientes.Services;

public class ServicesHospede
{
    private readonly HotelDbContext _context;

    public ServicesHospede(HotelDbContext context)
    {
        _context = context;
    }

    public async Task<List<Hospede>> GetAll()
    {
        return await _context.Hospedes.ToListAsync();
    }

    public async Task<Hospede> GetHospedeByid(int id)
    {
        var hospede = await _context.Hospedes.FirstOrDefaultAsync(x => x.Id == id);
        if (hospede == null)
            throw new Exception("Hospede não encontrado");
        return hospede;
    }

    public async Task Create(Hospede hospede)
    {
        await _context.Hospedes.AddAsync(hospede);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Hospede? hospede)
    {
        if (hospede == null)
            throw new ArgumentException("O Hospede passado é nulo");

        var hospedeEncontrado = await GetHospedeByid(hospede.Id);
        hospedeEncontrado.Celular = hospede.Celular;
        hospedeEncontrado.Email = hospede.Email;
        hospedeEncontrado.Nome = hospede.Nome;
        hospedeEncontrado.CPF = hospede.CPF;
        _context.Hospedes.Update(hospedeEncontrado);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    { 
        var hospedeARemover = await GetHospedeByid(id);
        _context.Hospedes.Remove(hospedeARemover);
        await _context.SaveChangesAsync();
    }
}