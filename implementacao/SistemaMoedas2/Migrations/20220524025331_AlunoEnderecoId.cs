using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaMoedas2.Migrations
{
    public partial class AlunoEnderecoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Instituicao_InstituicaoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_InstituicaoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Alunos");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_InstituicaoId",
                table: "Alunos",
                column: "InstituicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Instituicao_InstituicaoId",
                table: "Alunos",
                column: "InstituicaoId",
                principalTable: "Instituicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
