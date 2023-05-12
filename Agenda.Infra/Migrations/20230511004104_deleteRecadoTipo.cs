using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infra.Migrations
{
    /// <inheritdoc />
    public partial class deleteRecadoTipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recado_RecadoTipo_RecadoTipoId",
                table: "Recado");

            migrationBuilder.DropIndex(
                name: "IX_Recado_RecadoTipoId",
                table: "Recado");

            migrationBuilder.DropColumn(
                name: "RecadoTipoId",
                table: "Recado");

            migrationBuilder.AddColumn<string>(
                name: "RecadoTipo",
                table: "Recado",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecadoTipo",
                table: "Recado");

            migrationBuilder.AddColumn<int>(
                name: "RecadoTipoId",
                table: "Recado",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recado_RecadoTipoId",
                table: "Recado",
                column: "RecadoTipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recado_RecadoTipo_RecadoTipoId",
                table: "Recado",
                column: "RecadoTipoId",
                principalTable: "RecadoTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
