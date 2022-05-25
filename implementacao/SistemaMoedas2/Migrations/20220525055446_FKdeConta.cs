using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaMoedas2.Migrations
{
    public partial class FKdeConta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Alunos_ParticipanteId",
                table: "Conta");

            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Professores_ParticipanteId",
                table: "Conta");

            migrationBuilder.DropIndex(
                name: "IX_Conta_ParticipanteId",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "ParticipanteId",
                table: "Conta");

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Professores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Professores_ContaId",
                table: "Professores",
                column: "ContaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ContaId",
                table: "Alunos",
                column: "ContaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Conta_ContaId",
                table: "Alunos",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Conta_ContaId",
                table: "Professores",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Conta_ContaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Conta_ContaId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Professores_ContaId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_ContaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "ParticipanteId",
                table: "Conta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Conta_ParticipanteId",
                table: "Conta",
                column: "ParticipanteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Alunos_ParticipanteId",
                table: "Conta",
                column: "ParticipanteId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Professores_ParticipanteId",
                table: "Conta",
                column: "ParticipanteId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
