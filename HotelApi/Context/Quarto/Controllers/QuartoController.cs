using HotelApi.Context.Quarto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HotelApi.Context.Quarto.Controllers;

[ApiController]
[Route("v1")]
public class QuartoController : ControllerBase
{
    private readonly QuartoServico _quartoServico;

    public QuartoController(QuartoServico quartoServico)
    {
        _quartoServico = quartoServico;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var lista = await _quartoServico.GetAll();
        if (lista.Count == 0)
        {
            return NotFound("Lista de quartos vazia");
        }

        return Ok(lista);
    }

    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<IActionResult> GetQuartoById([FromRoute] string id)
    {
        var quarto = await _quartoServico.GetById(id);
        return Ok(quarto);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Insert([FromBody] Models.Quarto quarto)
    {
        try
        {
            await _quartoServico.InsertQuarto(quarto);
            return Created();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("Put")]
    public async Task<IActionResult> UpdateQuarto([FromBody] Models.Quarto quarto)
    {
        if (ModelState.IsValid)
        {
            await _quartoServico.Update(quarto);
            return Ok(quarto);
        }
        return BadRequest();
    }
}