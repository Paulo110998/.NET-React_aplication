using AutoMapper;
using Stepforma_BR.Data.Dtos;
using Stepforma_BR.Models;

namespace Stepforma_BR.Profiles;

public class DisciplinaProfile : Profile
{
    public DisciplinaProfile()
    {
        CreateMap<CreateDisciplinaDto, Disciplina>();

        CreateMap<Disciplina, ReadDisciplinaDto>();
            

        CreateMap<UpdateDisciplinaDto, Disciplina>();
    }
}
