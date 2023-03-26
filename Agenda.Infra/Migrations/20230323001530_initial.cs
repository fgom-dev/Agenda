using System;
using Agenda.Domain.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infra.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentoTipo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoTipo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DocumentoTipo",
                columns: new[]
                {
                    "Id",
                    "Nome",
                    "Descricao",
                    "CreatedAt",
                    "UpdatedAt"
                },
                values: new object[,]
                {
                    {
                        "a5fb0b49-2be8-4edd-8f01-57809c159d47",
                        "RA",
                        "Registro do Aluno",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        "38e9348c-295b-47b2-9435-918cbf88c9de",
                        "CPF",
                        "Cadastro de Pessoa Física",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        "4d7077a9-3b23-4019-8877-738ac89f8abc",
                        "RG",
                        "Registro Geral",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                });

            migrationBuilder.CreateTable(
                name: "PessoaTipo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaTipo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PessoaTipo",
                columns: new[]
                {
                    "Id",
                    "Nome",
                    "Descricao",
                    "CreatedAt",
                    "UpdatedAt"
                },
                values: new object[,]
                {
                    {
                        "6fee2fd8-98be-4798-ab86-17303baac02c",
                        "Aluno",
                        "Tipo Aluno",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        "c41ef195-44aa-4769-a31d-ecb0b2c2647b",
                        "Professor",
                        "Tipo Professor",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        "30a02a26-d24e-4f08-b54a-001aed053ce0",
                        "Coordenador",
                        "Tipo Coordenador",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },

                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PessoaTipoId = table.Column<Guid>(type: "uuid", nullable: true),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Sexo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DocumentoTipoId = table.Column<Guid>(type: "uuid", nullable: true),
                    Documento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_DocumentoTipo_DocumentoTipoId",
                        column: x => x.DocumentoTipoId,
                        principalTable: "DocumentoTipo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pessoa_PessoaTipo_PessoaTipoId",
                        column: x => x.PessoaTipoId,
                        principalTable: "PessoaTipo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoTipo_Nome",
                table: "DocumentoTipo",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_DocumentoTipoId",
                table: "Pessoa",
                column: "DocumentoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_PessoaTipoId",
                table: "Pessoa",
                column: "PessoaTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaTipo_Nome",
                table: "PessoaTipo",
                column: "Nome",
                unique: true);

            migrationBuilder.InsertData(
                table: "Pessoa",
                columns: new[]
                {
                    "Id",
                    "PessoaTipoId",                    
                    "Nome",
                    "Sobrenome",
                    "DataNascimento",
                    "Sexo",
                    "DocumentoTipoId",
                    "Documento",
                    "CreatedAt",
                    "UpdatedAt"
                },
                values: new object[,]
                {
                    {
                        "8b90c829-57d6-4a4a-9d5d-1f067c66d5d2",
                        "6fee2fd8-98be-4798-ab86-17303baac02c",
                        "Aluno1",
                        "Silva",
                        DateTime.Parse("1994-05-02 13:16:34.115").ToUniversalTime(),
                        "Maculino",
                        "a5fb0b49-2be8-4edd-8f01-57809c159d47",
                        "123456789",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        "480c4f52-307b-40de-a130-b3c6c805f6b6",
                        "6fee2fd8-98be-4798-ab86-17303baac02c",
                        "Aluno2",
                        "Souza",
                        DateTime.Parse("1995-05-02 13:16:34.115").ToUniversalTime(),
                        "Feminino",
                        "a5fb0b49-2be8-4edd-8f01-57809c159d47",
                        "987654321",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        "5e4f3442-04f1-4271-ad1e-4a48064d93d4",
                        "c41ef195-44aa-4769-a31d-ecb0b2c2647b",
                        "Professor1",
                        "Oliveira",
                        DateTime.Parse("1985-02-07 13:16:34.115").ToUniversalTime(),
                        "Maculino",
                        "38e9348c-295b-47b2-9435-918cbf88c9de",
                        "78945623125",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        "61aa2ade-ba09-4f44-b254-d331f3432e8b",
                        "c41ef195-44aa-4769-a31d-ecb0b2c2647b",
                        "Professor2",
                        "Cardoso",
                        DateTime.Parse("1980-01-08 13:16:34.115").ToUniversalTime(),
                        "Feminino",
                        "38e9348c-295b-47b2-9435-918cbf88c9de",
                        "78941563125",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        "03144c2c-7ff4-4084-a05f-9cf2071e5ba7",
                        "30a02a26-d24e-4f08-b54a-001aed053ce0",
                        "Coordenador1",
                        "Silva",
                        DateTime.Parse("1981-10-08 13:16:34.115").ToUniversalTime(),
                        "Masculino",
                        "4d7077a9-3b23-4019-8877-738ac89f8abc",
                        "354741265",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        "3a2d4e01-6703-46b7-bd6b-9de93067b94e",
                        "30a02a26-d24e-4f08-b54a-001aed053ce0",
                        "Coordenador2",
                        "Cardoso",
                        DateTime.Parse("1980-06-25 13:16:34.115").ToUniversalTime(),
                        "Feminino",
                        "4d7077a9-3b23-4019-8877-738ac89f8abc",
                        "1295447856",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },

                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "DocumentoTipo");

            migrationBuilder.DropTable(
                name: "PessoaTipo");
        }
    }
}
