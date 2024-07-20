using System.Diagnostics.CodeAnalysis;
using HotelApi.Context.DTOs;
using HotelApi.Context.Hospedes.Models;
using HotelApi.Context.Hospedes.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Context.Hospedes.Controllers;

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
    [Route("Create")]
    [SuppressMessage("ReSharper.DPA", "DPA0011: High execution time of MVC action", MessageId = "time: 1244ms")]
    public async Task<IActionResult> CreateAsync([FromBody] HospedeDTO hospedeDto)
    {
        await _servicesHospede.Create(hospedeDto);
        return CreatedAtAction(nameof(CreateAsync), new { CPF = hospedeDto.CPF }, hospedeDto);
    }

    [HttpPut]
    [Route("UpdatePut/{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody] HospedeDTO hospede, [FromRoute] int id)
    {
        try
        {
            await _servicesHospede.Update(id, hospede);
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