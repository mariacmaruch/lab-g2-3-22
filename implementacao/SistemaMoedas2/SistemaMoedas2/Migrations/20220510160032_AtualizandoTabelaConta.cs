using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaMoedas2.Migrations
{
    public partial class AtualizandoTabelaConta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Conta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Conta");
        }
    }
}
