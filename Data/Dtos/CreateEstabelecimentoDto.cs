using System.ComponentModel.DataAnnotations;

namespace Stepforma_BR.Data.Dtos;

public class CreateEstabelecimentoDto
{
    [Required(ErrorMessage = "O campo 'Titulo' é obrigatório!")]
    public string TituloEstabelecimento { get; set; }

    public string? EnderecoEstabelecimento { get; set; }
}
