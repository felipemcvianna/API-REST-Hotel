using HotelApi.Context.Hospedes.Models;
using HotelApi.Context.Quarto.Models;
using HotelApi.Context.Reserva.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data;

public class HotelDbContext(DbContextOptions<HotelDbContext> options) : DbContext(options)
{
    public DbSet<Quarto> Quartos { get; set; }
    public DbSet<Hospede> Hospedes { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    
}