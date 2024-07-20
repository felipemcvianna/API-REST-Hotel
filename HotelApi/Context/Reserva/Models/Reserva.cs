using HotelApi.Context.Hospedes.Models;

namespace HotelApi.Context.Reserva.Models;

public class Reserva
{
    public int Id { get; set; }
    public int QuartoId { get; set; }
    public Quarto.Models.Quarto? Quarto { get; set; }
    public ICollection<Hospede> Hospedes { get; set; } = new List<Hospede>();
    public DateTime CheckIn { get; set; }
    public bool CheckInConcluido { get; set; } = false;
    public DateTime CheckOut { get; set; }
    public bool CheckOutConcluido { get; set; } = false;
}