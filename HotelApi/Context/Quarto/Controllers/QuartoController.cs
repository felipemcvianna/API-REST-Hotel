using System.Diagnostics.CodeAnalysis;
using HotelApi.Context.DTOs;
using HotelApi.Context.Quarto.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Context.Quarto.Controllers;

[ApiController]
[Route("v1/quarto")]
public class QuartoController : ControllerBase
{
    private readonly ServicesQuarto _servicesQuarto;

    public QuartoController(ServicesQuarto servicesQuarto)
    {
        _servicesQuarto = servicesQuarto;
    }

    [HttpGet]
    [Route("GetAll")]
    [SuppressMessage("ReSharper.DPA", "DPA0011: High execution time of MVC action", MessageId = "time: 1187ms")]
    public async Task<IActionResult> GetAllAsync()
    {
        var lista = await _servicesQuarto.GetAll();
        if (lista.Count == 0)
        {
            return NotFound("Lista de quartos vazia");
        }

        return Ok(lista);
    }

    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var quarto = await _servicesQuarto.GetById(id);
        return Ok(quarto);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> InsertAsync([FromBody] QuartoDTO quarto)
    {
        try
        {
            await _servicesQuarto.InsertQuarto(quarto);
            return Created();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("UpdatePut/{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] QuartoDTO quarto)
    {
        try
        {
            await _servicesQuarto.Update(id, quarto);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

        return NoContent();
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        if (ModelState.IsValid)
        {
            await _servicesQuarto.Delete(id);
            return NoContent();
        }

        return BadRequest();
    }
}