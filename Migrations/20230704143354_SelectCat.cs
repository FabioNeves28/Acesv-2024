using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acesvv.Migrations
{
    public partial class SelectCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {






            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Dados");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaSelecionada",
                table: "Dados",
                type: "int",
                nullable: false,
                defaultValue: 0);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "CategoriaSelecionada",
                table: "Dados");



            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Dados",
                type: "nvarchar(max)",
                nullable: true);

        }
    }
}
