using System.ComponentModel.DataAnnotations;

namespace Stepforma_BR.Data.Dtos;

public class LoginUsuarioDto
{
    [Required]
    public string Username { get; set; }

    [Required] 
    public string Password { get; set;  }
}
