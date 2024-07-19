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
    public async Task<IActionResult> InsertAsync([FromBody] Models.Quarto quarto)
    {
        try
        {
            await _servicesQuarto.InsertQuarto(quarto);
            return CreatedAtAction(nameof(InsertAsync), new { id = quarto.Id }, quarto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("UpdatePut")]
    public async Task<IActionResult> UpdateAsync([FromBody] Models.Quarto quarto)
    {
        try
        {
            await _servicesQuarto.Update(quarto);
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