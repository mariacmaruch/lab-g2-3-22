using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaMoedas2.Migrations
{
    public partial class ModificacaoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Conta_ContaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Enderecos_EnderecoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Conta_ContaId",
                table: "Professor");

            migrationBuilder.DropIndex(
                name: "IX_Professor_ContaId",
                table: "Professor");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_ContaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_EnderecoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Alunos");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Professor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Professor_ContaId",
                table: "Professor",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ContaId",
                table: "Alunos",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_EnderecoId",
                table: "Alunos",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Conta_ContaId",
                table: "Alunos",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Enderecos_EnderecoId",
                table: "Alunos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Conta_ContaId",
                table: "Professor",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
