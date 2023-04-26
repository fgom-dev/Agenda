using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioIdOnRecado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "RecadoTipo",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "RecadoTipo",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "RecadoStatus",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "RecadoStatus",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Recado",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecadoTipo_Nome",
                table: "RecadoTipo",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecadoStatus_Nome",
                table: "RecadoStatus",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recado_UsuarioId",
                table: "Recado",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recado_Usuario_UsuarioId",
                table: "Recado",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recado_Usuario_UsuarioId",
                table: "Recado");

            migrationBuilder.DropIndex(
                name: "IX_RecadoTipo_Nome",
                table: "RecadoTipo");

            migrationBuilder.DropIndex(
                name: "IX_RecadoStatus_Nome",
                table: "RecadoStatus");

            migrationBuilder.DropIndex(
                name: "IX_Recado_UsuarioId",
                table: "Recado");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Recado");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "RecadoTipo",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "RecadoTipo",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "RecadoStatus",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "RecadoStatus",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
