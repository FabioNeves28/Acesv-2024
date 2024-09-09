using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acesvv.Migrations
{
    public partial class Financeiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Financeiro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo_Mes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arrecadacao_Mensalidade_Atrasada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arrecadacao_Mensalidade_Antecipadas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total_Entradas = table.Column<double>(type: "float", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contabilidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarifa_Bancaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apolice_Seguro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Advogada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Renovacao_Assinatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Taxas_Bancarias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Taxa_Internet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total_Gastos = table.Column<double>(type: "float", nullable: false),
                    Total_Liquido = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiro", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financeiro");
        }
    }
}
