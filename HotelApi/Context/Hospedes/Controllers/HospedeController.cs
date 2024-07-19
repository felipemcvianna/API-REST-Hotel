using System.Diagnostics.CodeAnalysis;
using HotelApi.Context.Clientes.Models;
using HotelApi.Context.Clientes.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Context.Clientes.Controllers;

[ApiController]
[Route("v1/hospede")]
public class HospedeController : ControllerBase
{
    private readonly ServicesHospede _servicesHospede;

    public HospedeController(ServicesHospede servicesHospede)
    {
        _servicesHospede = servicesHospede;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        var listHospede = await _servicesHospede.GetAll();
        if (listHospede.Count == 0)
            return NotFound("Lista de hospedes vazia");
        return Ok(listHospede);
    }

    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<IActionResult> GetHospedeByid([FromRoute] int id)
    {
        try
        {
            var hospede = await _servicesHospede.GetHospedeByid(id);
            return Ok(hospede);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpPost]
    [Route("CreateAsync")]
    public async Task<IActionResult> CreateAsync([FromBody] Hospede hospede)
    {
        await _servicesHospede.Create(hospede);
        return CreatedAtAction(nameof(CreateAsync), new { id = hospede.Id }, hospede);
    }

    [HttpPut]
    [Route("UpdatePut")]
    public async Task<IActionResult> UpdateAsync([FromBody] Hospede? hospede)
    {
        try
        {
            await _servicesHospede.Update(hospede);
            return Ok(hospede);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
           await _servicesHospede.Delete(id);
           return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}