namespace Stepforma_BR.Data.Dtos;

public class ReadEstabelecimentoDto
{
    public int Id { get; set; }
    public string TituloEstabelecimento { get; set; }

    public string? EnderecoEstabelecimento { get; set; }

    public ICollection<ReadTurmaDto> ReadTurmas { get; set; }

   
  
}
