using HotelApi.Context.Quarto.Services;

namespace HotelApi.Context.Quarto;

public static class QuartoConfiguration
{
    public static WebApplicationBuilder AddArquitecture(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<QuartoServico>();
        return builder;
    }

    public static WebApplication AddAppQuarto(this WebApplication app)
    {
        app.MapControllers();
        app.MapControllerRoute("/api/Quarto", "{controller=Quarto}/{action=GetAll}/{id?}");
        return app;
    }
}