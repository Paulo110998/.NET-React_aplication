using Stepforma_BR.Migrations;
using System.ComponentModel.DataAnnotations;

namespace Stepforma_BR.Models;

public class Estabelecimento 
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo 'Titulo' é obrigatório!")]
    public string TituloEstabelecimento { get; set; }

    public string? EnderecoEstabelecimento { get; set; }

    public virtual ICollection<Turma> Turmas { get; set; }

   
}
