using HotelApi.Context.DTOs;
using HotelApi.Context.Hospedes.Models;
using HotelApi.Context.Quarto.Models.Enums;
using HotelApi.Context.Quarto.Services;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Context.Reserva.Services;

public class ServiceReserva
{
    private readonly HotelDbContext _context;
    private readonly Logger<ServiceReserva> _logger;
    private readonly ServicesQuarto _servicesQuarto;

    public ServiceReserva(HotelDbContext context, Logger<ServiceReserva> logger, ServicesQuarto servicesQuarto)
    {
        _context = context;
        _logger = logger;
        _servicesQuarto = servicesQuarto;
    }

    public async Task<List<Models.Reserva>> GetAll()
    {
        var list = await _context.Reservas
            .Include(r => r.Hospedes)
            .ToListAsync();

        _logger.LogInformation("Entrando na lista de hospedes");
        foreach (var reservas in list)
        {
            foreach (var hospedes in reservas.Hospedes)
            {
                _logger.LogInformation($"Nome do hospede: {hospedes.Nome}");
            }
        }

        return list;
    }

    public async Task<Models.Reserva> GetReservaById(int id)
    {
        var reserva = await _context.Reservas
            .Include(x => x.Hospedes)
            .Include(e => e.Quarto)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (reserva == null)
            throw new ArgumentException(nameof(reserva), "Reserva não encontrada");

        return reserva;
    }

    public async Task Create(ReservaDTO reservaDto)
    {
        if (reservaDto == null)
            throw new ArgumentException("A reserva não pode ser vazia", nameof(reservaDto));

        var quarto = await _context.Quartos.FindAsync(reservaDto.QuartoId);
        if (quarto == null)
            throw new ArgumentException(nameof(reservaDto.QuartoId), "O quarto não existe");

        var reserva = new Models.Reserva()
        {
            QuartoId = reservaDto.QuartoId,
            Quarto = quarto,
            CheckIn = reservaDto.CheckIn,
            CheckOut = reservaDto.CheckOut,
            CheckInConcluido = false,
            CheckOutConcluido = false,
            Hospedes = reservaDto.Hospedes.Select(h => new Hospede
            {
                Nome = h.Nome,
                Email = h.Email,
                Celular = h.Celular,
                CPF = h.CPF
            }).ToList()
        };

        quarto.Reserva = reserva;
        await _servicesQuarto.PreencherVagasQuarto(quarto.Id);

        await _context.Reservas.AddAsync(reserva);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCheckInDate(int id, DateTime newDate)
    {
        var reserva = await GetReservaById(id);
        reserva.CheckIn = newDate;
        _context.Update(reserva);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCheckOutDate(int id, DateTime newDate)
    {
        var reserva = await GetReservaById(id);
        reserva.CheckOut = newDate;
        _context.Update(reserva);
        await _context.SaveChangesAsync();
    }

    public async Task CheckIn(int id)
    {
        var reserva = await GetReservaById(id);

        if (DateTime.Now >= reserva.CheckIn)
        {
            reserva.CheckInConcluido = true;
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception(
                $"O Check-in não pode ser concluído. Hoje é dia {DateTime.Now}, e o check-in é dia {reserva.CheckIn.Date}");
        }
    }


    public async Task CheckOut(int id)
    {
        var reserva = await GetReservaById(id);

        if (reserva.Quarto == null)
            throw new ArgumentNullException(nameof(reserva), "a reserva não tem um quarto atribuido");

        if (!reserva.CheckInConcluido)
            throw new Exception("Faça o CheckIn para fazer CheckOut");
        reserva.CheckOutConcluido = true;
        reserva.Quarto.Reserva = null;
        await _servicesQuarto.EsvaziarQuarto(reserva.QuartoId);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var reserva = await GetReservaById(id);
        _context.Reservas.Remove(reserva);
        await _context.SaveChangesAsync();
    }
}