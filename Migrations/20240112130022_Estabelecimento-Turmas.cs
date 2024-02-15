using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stepforma_BR.Migrations
{
    public partial class EstabelecimentoTurmas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Turmas_EstabelecimentoId",
                table: "Turmas");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_EstabelecimentoId",
                table: "Turmas",
                column: "EstabelecimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Turmas_EstabelecimentoId",
                table: "Turmas");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_EstabelecimentoId",
                table: "Turmas",
                column: "EstabelecimentoId",
                unique: true);
        }
    }
}
