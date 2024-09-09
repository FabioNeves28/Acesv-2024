using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acesvv.Migrations
{
    public partial class List : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dados_Escolas_EscolaId",
                table: "Dados");

            migrationBuilder.DropIndex(
                name: "IX_Dados_EscolaId",
                table: "Dados");

            migrationBuilder.RenameColumn(
                name: "EscolaId",
                table: "Dados",
                newName: "Escolas");

            migrationBuilder.AlterColumn<string>(
                name: "Escolas",
                table: "Dados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EscolaId1",
                table: "Dados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dados_EscolaId1",
                table: "Dados",
                column: "EscolaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Dados_Escolas_EscolaId1",
                table: "Dados",
                column: "EscolaId1",
                principalTable: "Escolas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dados_Escolas_EscolaId1",
                table: "Dados");

            migrationBuilder.DropIndex(
                name: "IX_Dados_EscolaId1",
                table: "Dados");

            migrationBuilder.DropColumn(
                name: "EscolaId1",
                table: "Dados");

            migrationBuilder.RenameColumn(
                name: "Escolas",
                table: "Dados",
                newName: "EscolaId");

            migrationBuilder.AlterColumn<int>(
                name: "EscolaId",
                table: "Dados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dados_EscolaId",
                table: "Dados",
                column: "EscolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dados_Escolas_EscolaId",
                table: "Dados",
                column: "EscolaId",
                principalTable: "Escolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
