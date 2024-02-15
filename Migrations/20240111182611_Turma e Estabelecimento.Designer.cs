﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Stepforma_BR.Migrations
{
    [DbContext(typeof(ContextStep))]
    [Migration("20240111182611_Turma e Estabelecimento")]
    partial class TurmaeEstabelecimento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Stepforma_BR.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DescricaoDisciplina")
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("Stepforma_BR.Models.Estabelecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EnderecoEstabelecimento")
                        .HasColumnType("longtext");

                    b.Property<string>("TituloEstabelecimento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Estabelecimentos");
                });

            modelBuilder.Entity("Stepforma_BR.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CargaHoraria")
                        .HasColumnType("longtext");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<int?>("EstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId")
                        .IsUnique();

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("Stepforma_BR.Models.Disciplina", b =>
                {
                    b.HasOne("Stepforma_BR.Models.Turma", "Turma")
                        .WithMany("Disciplinas")
                        .HasForeignKey("TurmaId");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Stepforma_BR.Models.Turma", b =>
                {
                    b.HasOne("Stepforma_BR.Models.Estabelecimento", "Estabelecimento")
                        .WithOne("Turma")
                        .HasForeignKey("Stepforma_BR.Models.Turma", "EstabelecimentoId");

                    b.Navigation("Estabelecimento");
                });

            modelBuilder.Entity("Stepforma_BR.Models.Estabelecimento", b =>
                {
                    b.Navigation("Turma")
                        .IsRequired();
                });

            modelBuilder.Entity("Stepforma_BR.Models.Turma", b =>
                {
                    b.Navigation("Disciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}