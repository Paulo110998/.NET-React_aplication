using System.ComponentModel.DataAnnotations;

namespace Stepforma_BR.Data.Dtos;

public class UpdateDisciplinaDto
{

    [Required(ErrorMessage = "Campo 'Título' é obrigatório!")]
    public string Titulo { get; set; }

    public string? DescricaoDisciplina { get; set; }

    public int TurmaId { get; set; }
}
