using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterRecadoStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recado_RecadoStatus_RecadoStatusId",
                table: "Recado");

            migrationBuilder.DropIndex(
                name: "IX_Recado_RecadoStatusId",
                table: "Recado");

            migrationBuilder.DropColumn(
                name: "RecadoStatusId",
                table: "Recado");

            migrationBuilder.AddColumn<int>(
                name: "RecadoStatusId",
                table: "PessoaRecado",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PessoaRecado_RecadoStatusId",
                table: "PessoaRecado",
                column: "RecadoStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaRecado_RecadoStatus_RecadoStatusId",
                table: "PessoaRecado",
                column: "RecadoStatusId",
                principalTable: "RecadoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoaRecado_RecadoStatus_RecadoStatusId",
                table: "PessoaRecado");

            migrationBuilder.DropIndex(
                name: "IX_PessoaRecado_RecadoStatusId",
                table: "PessoaRecado");

            migrationBuilder.DropColumn(
                name: "RecadoStatusId",
                table: "PessoaRecado");

            migrationBuilder.AddColumn<int>(
                name: "RecadoStatusId",
                table: "Recado",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recado_RecadoStatusId",
                table: "Recado",
                column: "RecadoStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recado_RecadoStatus_RecadoStatusId",
                table: "Recado",
                column: "RecadoStatusId",
                principalTable: "RecadoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
