using System.ComponentModel.DataAnnotations;
namespace Stepforma_BR.Models;

public class Turma
{
    [Key]
    [Required]
    public int Id {get; set;}

    [Required(ErrorMessage = "Este campo é obrigratório")]
    [StringLength(100)]
    public string Titulo {get; set;}

    public string? Descricao {get; set;}

    public string? CargaHoraria { get; set; }

    public virtual ICollection<Disciplina> Disciplinas { get; set;}

    public virtual Categorias Categorias { get; set; }

    public int? EstabelecimentoId { get; set; }
    public virtual Estabelecimento Estabelecimento { get; set; }





}