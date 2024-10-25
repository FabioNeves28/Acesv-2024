using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Acesvv.Areas.Identity.Data;

// Add profile data for application users by adding properties to the UsuarioModel class
public class UsuarioModel : IdentityUser
{

    [MaxLength(15, ErrorMessage = "O tamanho máximo do campo {0} é de (1) caracteres")]

    public string? Telefone { get; set; }
    [MaxLength(15, ErrorMessage = "O tamanho máximo do campo {0} é de (1) caracteres")]
    public string Nome { get; set; }

    [MaxLength(11, ErrorMessage = "O tamanho máximo do campo {0} é de (1) caracteres")]
    public string Cpf { get; set; }
    public int? Chave_ADM { get; set; }
}

