using Stepforma_BR.Models;
using System.ComponentModel.DataAnnotations;

namespace Stepforma_BR.Data.Dtos;

public class CreateCategoriaDto
{
    [Required(ErrorMessage = "Campo 'Título' é obrigatório!")]
    public string TituloCategoria { get; set; }

    public int TurmaId { get; set; }
   
}
