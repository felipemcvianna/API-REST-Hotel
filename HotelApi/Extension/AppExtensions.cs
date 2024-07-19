using HotelApi.Context.Quarto;

namespace HotelApi.Extension;

public static class AppExtensions
{
    public static WebApplication AddAppConfigurations(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.MapControllers();
        app.MapControllerRoute("Quartos", "{controller=Quarto}/{action=GetAll}/{id?}");
        return app;
    }
}