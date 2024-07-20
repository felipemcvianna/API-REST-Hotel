using HotelApi.Context.Quarto.Models.Enums;

namespace HotelApi.Context.DTOs;

public class QuartoDTO
{
    public int Numero { get; set; }
    public int Vagas { get; set; }
    public Status Status { get; set; }
    
}