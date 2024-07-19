using HotelApi.Context.Clientes.Models;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Context.Reserva.Services;

public class ServiceReserva
{
    private readonly HotelDbContext _context;

    public ServiceReserva(HotelDbContext context)
    {
        _context = context;
    }

    public async Task<List<Models.Reserva>> GetAll()
    {
        return await _context.Reservas.ToListAsync();
    }
    
    public async Task Create(Models.Reserva reserva)
    {
        await _context.Reservas.AddAsync(reserva);
        await _context.SaveChangesAsync();
    }
}