using HotelApi.Context.Quarto.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data;

public class HotelDbContext(DbContextOptions<HotelDbContext> options) : DbContext(options)
{
    public DbSet<Quarto> Quartos { get; set; }
}