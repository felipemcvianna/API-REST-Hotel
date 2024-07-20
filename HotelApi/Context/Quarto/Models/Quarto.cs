using System.ComponentModel.DataAnnotations.Schema;
using HotelApi.Context.Hospedes.Models;
using HotelApi.Context.Quarto.Models.Enums;

namespace HotelApi.Context.Quarto.Models;

public class Quarto
{
    public int Id { get; set; }
    public int Numero { get; set; }
    public Status Status { get; set; }
    public int Vagas { get; set; }
    public int SalvarVagas { get; set; }
    public ICollection<Hospede> Hospedes { get; set; } = new List<Hospede>();
    public Reserva.Models.Reserva? Reserva { get; set; }
    
}