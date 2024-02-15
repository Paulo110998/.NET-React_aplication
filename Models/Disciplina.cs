using System.ComponentModel.DataAnnotations;

namespace Stepforma_BR.Models;

public class Disciplina
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo 'Título' é obrigatório!")]
    public string Titulo { get; set; }

    public string? DescricaoDisciplina { get; set; }

    public int? TurmaId { get; set; }
    public virtual Turma Turma { get; set; }



}
