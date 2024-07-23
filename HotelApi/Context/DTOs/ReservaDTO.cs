using HotelApi.Context.Hospedes.Models;

namespace HotelApi.Context.DTOs;

public class ReservaDTO
{
    public int QuartoId { get; set; }
    public DateTime CheckIn { get; set; }
    public List<string> CPF { get; set; } = new List<string>();
    public DateTime CheckOut { get; set; }
}