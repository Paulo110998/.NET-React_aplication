using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Stepforma_BR.Data;
using Stepforma_BR.Data.Dtos;
using Stepforma_BR.Services;

namespace Stepforma_BR.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuariosController : ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuariosController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastroUserAsync(
        CreateUsuarioDto usuarioDto)
    {
        await _usuarioService.Cadastrar(usuarioDto);
        return Ok("Usuário cadastrado com sucesso!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUserAsync(
        LoginUsuarioDto loginDto)
    {
        var token = await _usuarioService.Login(loginDto);
        return Ok($"Bem-vindo a sua conta {loginDto.Username} ! Seu Token -> "+token);
    }
}
