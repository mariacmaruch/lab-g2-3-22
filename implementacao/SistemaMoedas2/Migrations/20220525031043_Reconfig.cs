using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaMoedas2.Migrations
{
    public partial class Reconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Instituicao_InstituicaoId",
                table: "Professor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professor",
                table: "Professor");

            migrationBuilder.RenameTable(
                name: "Professor",
                newName: "Professores");

            migrationBuilder.RenameIndex(
                name: "IX_Professor_InstituicaoId",
                table: "Professores",
                newName: "IX_Professores_InstituicaoId");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Conta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoId",
                table: "Professores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professores",
                table: "Professores",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_AlunoId",
                table: "Conta",
                column: "AlunoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Alunos_AlunoId",
                table: "Conta",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Instituicao_InstituicaoId",
                table: "Professores",
                column: "InstituicaoId",
                principalTable: "Instituicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Alunos_AlunoId",
                table: "Conta");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Instituicao_InstituicaoId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Conta_AlunoId",
                table: "Conta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professores",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Conta");

            migrationBuilder.RenameTable(
                name: "Professores",
                newName: "Professor");

            migrationBuilder.RenameIndex(
                name: "IX_Professores_InstituicaoId",
                table: "Professor",
                newName: "IX_Professor_InstituicaoId");

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoId",
                table: "Professor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professor",
                table: "Professor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Instituicao_InstituicaoId",
                table: "Professor",
                column: "InstituicaoId",
                principalTable: "Instituicao",
                principalColumn: "Id");
        }
    }
}
