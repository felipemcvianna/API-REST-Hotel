using HotelApi.Context.Reserva.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Context.Reserva.Controllers;

[ApiController]
[Route("v1/reservas")]
public class ReservaController : ControllerBase
{
    private readonly ServiceReserva _serviceReserva;

    public ReservaController(ServiceReserva serviceReserva)
    {
        _serviceReserva = serviceReserva;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var lista = await _serviceReserva.GetAll();
        if (!lista.Any())
            return NotFound("Lista de reservas vazia");
        return Ok(lista);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateReserva([FromBody] Models.Reserva reserva)
    {
        await _serviceReserva.Create(reserva);
        return Created();
    }
}