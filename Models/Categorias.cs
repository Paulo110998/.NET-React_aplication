using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Stepforma_BR.Models;


public class Categorias 
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo 'Título' é obrigatório!")]
    public string TituloCategoria { get; set; }

    public int TurmaId { get; set; }
    public virtual Turma Turma { get; set; }
}
