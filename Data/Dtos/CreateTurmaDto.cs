using System.ComponentModel.DataAnnotations;

namespace Stepforma_BR.Data.Dtos;

public class CreateTurmaDto
{
    
    [Required(ErrorMessage = "Este campo é obrigratório")]
    [StringLength(100)]
    public string Titulo { get; set; }

    public string? Descricao { get; set; }

    public string? CargaHoraria { get; set; }

    public int EstabelecimentoId { get; set; }


}
