using AutoMapper;
using Stepforma_BR.Data.Dtos;
using Stepforma_BR.Models;

namespace Stepforma_BR.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile() 
    {
        CreateMap<CreateUsuarioDto, Usuario>();
    
    }
}
