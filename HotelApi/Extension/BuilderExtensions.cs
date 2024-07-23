using System.Text.Json.Serialization;
using HotelApi.Context.Hospedes.Services;
using HotelApi.Context.Quarto.Services;
using HotelApi.Context.Reserva.Services;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Extension;

public static class BuilderExtensions
{
    public static WebApplicationBuilder AddBuilderConfigurations(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        });

        builder.Services.AddScoped<ServicesQuarto>();

        builder.Services.AddScoped<ServiceReserva>();
        builder.Services.AddScoped<Logger<ServiceReserva>>();

        builder.Services.AddScoped<ServicesHospede>();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<HotelDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        
        return builder;
    }
}