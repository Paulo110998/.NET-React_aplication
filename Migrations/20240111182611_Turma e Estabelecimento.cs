using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stepforma_BR.Migrations
{
    public partial class TurmaeEstabelecimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstabelecimentoId",
                table: "Turmas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_EstabelecimentoId",
                table: "Turmas",
                column: "EstabelecimentoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Estabelecimentos_EstabelecimentoId",
                table: "Turmas",
                column: "EstabelecimentoId",
                principalTable: "Estabelecimentos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Estabelecimentos_EstabelecimentoId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_EstabelecimentoId",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "EstabelecimentoId",
                table: "Turmas");
        }
    }
}
