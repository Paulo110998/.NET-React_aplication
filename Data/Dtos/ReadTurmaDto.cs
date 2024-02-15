
namespace Stepforma_BR.Data.Dtos;

public class ReadTurmaDto
{
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string? Descricao { get; set; }

    public string? CargaHoraria { get; set; }

    public ICollection<ReadDisciplinaDto> ReadDisciplinasDto { get; set; }

    public ReadCategoriaDto Categoria { get; set; }

    public int EstabelecimentoId { get; set; }

    





}
