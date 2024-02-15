using Microsoft.EntityFrameworkCore;
using Stepforma_BR.Models;
using System;

public class ContextStep : DbContext
{
	public ContextStep(DbContextOptions<ContextStep> options)
		:base(options)
	{

	}

  //  protected override void OnModelCreating(ModelBuilder builder)
  //  {
  //      builder.Entity<Turma>()
		//	.HasKey(turma => new { turma.EstabelecimentoId });

		//builder.Entity<Turma>()
		//	// Uma turma possui um estabelecimento
		//	.HasOne(turma => turma.Estabelecimento)
		//	// Um estabelecimento possui uma ou mais turmas
		//	.WithMany(estabelecimento => estabelecimento.)
		//	.HasForeignKey(turma => turma.EstabelecimentoId);
  //  }

    public DbSet<Turma> Turmas { get; set; }

	public DbSet<Disciplina> Disciplinas { get; set;}

	public DbSet<Categorias> Categorias { get; set; }

	public DbSet<Estabelecimento> Estabelecimentos { get; set; }

}
