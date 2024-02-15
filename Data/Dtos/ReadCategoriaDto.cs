using Stepforma_BR.Models;
using System.ComponentModel.DataAnnotations;

namespace Stepforma_BR.Data.Dtos;

public class ReadCategoriaDto
{
    public int Id { get; set; }

    public string TituloCategoria { get; set; }

    public int TurmaId { get; set; }
    
}
