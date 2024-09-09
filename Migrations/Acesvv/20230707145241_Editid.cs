using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acesvv.Migrations.Acesvv
{
    public partial class Editid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EditId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "29, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditId",
                table: "AspNetUsers");
        }
    }
}
