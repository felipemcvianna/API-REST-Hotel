using HotelApi.Context.Quarto.Models.Enums;

namespace HotelApi.Context.Quarto.Models;

public class Quarto
{
    public required int Id { get; set; }
    public int Numero { get; set; }
    public Status Status { get; set; }
    public int Vagas { get; set; }
    public Reserva.Models.Reserva? Reserva { get; set; }

    public void PreencherVaga()
    {
        if (Vagas == 0)
            throw new InvalidOperationException("Não há vagas");
        Vagas -= 1;
    }

    public void Verification()
    {
        if (Reserva == null)
        {
            if (Reserva.Hospedes.Count > Vagas)
            {
                Status = Status.Indisponivel;
            }
        }

        Status = Status.Disponivel;
    }
}