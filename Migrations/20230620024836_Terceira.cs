using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acesvv.Migrations
{
    public partial class Terceira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EscolasFormatadas",
                table: "Dados",
                newName: "EscolasSelecionadas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EscolasSelecionadas",
                table: "Dados",
                newName: "EscolasFormatadas");
        }
    }
}
