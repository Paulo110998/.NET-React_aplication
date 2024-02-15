using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Stepforma_BR.Data.Dtos;
using Stepforma_BR.Models;

namespace Stepforma_BR.Services;

public class UsuarioService 
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;
    private SignInManager<Usuario>_singInManager;
    private TokenService _tokenService;

    public UsuarioService(IMapper mapper,
        UserManager<Usuario> userManager, 
        SignInManager<Usuario> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _singInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task Cadastrar(CreateUsuarioDto usuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

        IdentityResult result = await _userManager.CreateAsync(usuario, usuarioDto.Password);

        if (!result.Succeeded) 
        {
            throw new ApplicationException("Erro ao cadastrar usuário..");
        }
    }

    public async Task<string> Login(LoginUsuarioDto loginDto)
    {
        var resultado = await _singInManager.PasswordSignInAsync(
            loginDto.Username, loginDto.Password, false, false);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Erro ao acessar sua conta..");
        }

        // Buscando o u´suário
        var usuario = _singInManager.UserManager.Users.FirstOrDefault(
            user => user.NormalizedUserName == loginDto.Username.ToUpper());

        // Se os dados estiverem ok, geramos o token
        var token = _tokenService.GenerateToken(usuario);

        return token;
    }
}
