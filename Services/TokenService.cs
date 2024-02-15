using Microsoft.IdentityModel.Tokens;
using Stepforma_BR.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Stepforma_BR.Services;


public class TokenService
{
    private IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Usuario usuario)
    {
        // Reinvindicações de um usuário
        Claim[] claims = new Claim[]
        {
            new Claim("id", usuario.Id),
            new Claim("username", usuario.UserName),
            new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())

        };

        // GERANDO CHAVE
        var chave = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));


        // GERANDO CRENDENCIAIS A PARTIR DA CHAVE
        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);


        // GERANDO TOKEN 
        var token = new JwtSecurityToken(

            // Tempo de expiração
            expires: DateTime.Now.AddDays(1),

            // Reinvidicações de token de usuário
            claims: claims,

            // Credenciais
            signingCredentials : signingCredentials

            );

        // Retornando/convertendo token
        return new JwtSecurityTokenHandler().WriteToken(token);


    }
}
