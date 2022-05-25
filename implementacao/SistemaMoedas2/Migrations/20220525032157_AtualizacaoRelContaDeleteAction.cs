using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaMoedas2.Migrations
{
    public partial class AtualizacaoRelContaDeleteAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Alunos_AlunoId",
                table: "Conta");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Conta",
                newName: "ParticipanteId");

            migrationBuilder.RenameIndex(
                name: "IX_Conta_AlunoId",
                table: "Conta",
                newName: "IX_Conta_ParticipanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Alunos_ParticipanteId",
                table: "Conta",
                column: "ParticipanteId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Professores_ParticipanteId",
                table: "Conta",
                column: "ParticipanteId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Alunos_ParticipanteId",
                table: "Conta");

            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Professores_ParticipanteId",
                table: "Conta");

            migrationBuilder.RenameColumn(
                name: "ParticipanteId",
                table: "Conta",
                newName: "AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_Conta_ParticipanteId",
                table: "Conta",
                newName: "IX_Conta_AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Alunos_AlunoId",
                table: "Conta",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
