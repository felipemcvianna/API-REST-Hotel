using HotelApi.Context.Hospedes.Models;

namespace HotelApi.Context.DTOs;

public class ReservaDTO
{
    public int QuartoId { get; set; }
    public DateTime CheckIn { get; set; }
    public ICollection<HospedeDTO> Hospedes { get; set; } = new List<HospedeDTO>();
    public DateTime CheckOut { get; set; }
}