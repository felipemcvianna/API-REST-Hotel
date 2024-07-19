using System.ComponentModel.DataAnnotations;

namespace HotelApi.Context.Clientes.Models;

public class Hospede
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O Email é obrigatório")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "O celular é obrigatório")]
    public string Celular { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório")]
    public string CPF { get; set; }
}