using AutoMapper;
using Stepforma_BR.Data.Dtos;
using Stepforma_BR.Models;

namespace Stepforma_BR.Profiles;

public class CategoriaProfile : Profile
{
    public CategoriaProfile() 
    {
        CreateMap<CreateCategoriaDto, Categorias>();

        CreateMap<Categorias, ReadCategoriaDto>();

        CreateMap<UpdateCategoriaDto, Categorias>();
    
    }
}
