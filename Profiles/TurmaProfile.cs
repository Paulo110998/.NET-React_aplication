using AutoMapper;
using Stepforma_BR.Data.Dtos;
using Stepforma_BR.Models;

public class TurmaProfile : Profile
{
    public TurmaProfile()
    {
        CreateMap<CreateTurmaDto, Turma>();

        CreateMap<Turma, ReadTurmaDto>()
            .ForMember(turmaDto => turmaDto.ReadDisciplinasDto,
            opt => opt.MapFrom(turma => turma.Disciplinas))
            
            .ForMember(turmaDto => turmaDto.Categoria,
            opt => opt.MapFrom(turma => turma.Categorias));
            
            

        CreateMap<UpdateTurmaDto, Turma>();

    }

}
