using HotelApi.Context.Clientes.Services;
using HotelApi.Context.Quarto;
using HotelApi.Context.Quarto.Services;
using HotelApi.Context.Reserva.Services;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Extension;

public static class BuilderExtensions
{
    public static WebApplicationBuilder AddBuilderConfigurations(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services.AddScoped<ServicesQuarto>();

        builder.Services.AddScoped<ServiceReserva>();

        builder.Services.AddScoped<ServicesHospede>();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<HotelDbContext>(options => options
            .UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 37))));
        return builder;
    }
}