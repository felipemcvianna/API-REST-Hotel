using HotelApi.Context.Quarto;

namespace HotelApi.Extension;

public static class AppExtensions
{
    public static WebApplication AddAppConfigurations(this WebApplication app)
    {
        app.AddAppQuarto();
        app.UseHttpsRedirection();
        return app;
    }
}