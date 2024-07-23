using System.Diagnostics.CodeAnalysis;
using HotelApi.Context.DTOs;
using HotelApi.Context.Reserva.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Exception = System.Exception;

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
    [SuppressMessage("ReSharper.DPA", "DPA0011: High execution time of MVC action", MessageId = "time: 2455ms")]
    public async Task<IActionResult> GetAll()
    {
        var lista = await _serviceReserva.GetAll();
        if (!lista.Any())
            return NotFound("Lista de reservas vazia");
        return Ok(lista);
    }

    [HttpGet]
    [Route("GetById/{id}")]
    [SuppressMessage("ReSharper.DPA", "DPA0011: High execution time of MVC action", MessageId = "time: 1274ms")]
    public async Task<IActionResult> GetReservaById([FromRoute] int id)
    {
        try
        {
            var reserva = await _serviceReserva.GetReservaById(id);
            return Ok(reserva);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateReserva([FromBody] ReservaDTO reserva)
    {
        try
        {
            await _serviceReserva.Create(reserva);
            return Created();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch]
    [Route("CheckIn/{id}")]
    public async Task<IActionResult> CheckIn([FromRoute] int id)
    {
        try
        {
            await _serviceReserva.CheckIn(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch]
    [Route("CheckOut/{id}")]
    public async Task<IActionResult> CheckOut([FromRoute] int id)
    {
        try
        {
            await _serviceReserva.CheckOut(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch]
    [Route("UpdateCheckInDate/{id}")]
    public async Task<IActionResult> UpdateCheckInDate([FromRoute] int id, [FromBody] DateTime newDate)
    {
        try
        {
            await _serviceReserva.UpdateCheckInDate(id, newDate);
            return Ok("Objeto atualizado com sucesso");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPatch]
    [Route("UpdateCheckOutDate/{id}")]
    public async Task<IActionResult> UpdateCheckOutDate([FromRoute] int id, [FromBody] DateTime newDate)
    {
        try
        {
            await _serviceReserva.UpdateCheckOutDate(id, newDate);
            return Ok("Objeto atualizado com sucesso");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            await _serviceReserva.Delete(id);
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}