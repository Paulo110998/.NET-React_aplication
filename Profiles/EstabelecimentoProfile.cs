using AutoMapper;
using Stepforma_BR.Data.Dtos;
using Stepforma_BR.Models;

namespace Stepforma_BR.Profiles;

public class EstabelecimentoProfile : Profile
{
    public EstabelecimentoProfile() 
    {
        CreateMap<CreateEstabelecimentoDto, Estabelecimento>();

        CreateMap<Estabelecimento, ReadEstabelecimentoDto>()
            .ForMember(estabelecimentoDto => estabelecimentoDto.ReadTurmas,
            opt => opt.MapFrom(estabelecimento => estabelecimento.Turmas));

        CreateMap<UpdateEstabelecimentoDto, Estabelecimento>();

  
    }
}
