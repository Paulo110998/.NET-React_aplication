using Microsoft.AspNetCore.Identity;

namespace Stepforma_BR.Models;

public class Usuario : IdentityUser 
{
    public DateTime DataNascimento { get; set; }

    public Usuario() : base() { }
}
