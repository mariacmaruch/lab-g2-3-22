using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaMoedas2.Migrations
{
    public partial class Voltando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idInstituicao",
                table: "Alunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idInstituicao",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
