using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        1,
                        "RA",
                        "Registro do Aluno",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        2,
                        "CPF",
                        "Cadastro de Pessoa Física",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        3,
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        1,
                        "Aluno",
                        "Tipo Aluno",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        2,
                        "Professor",
                        "Tipo Professor",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        3,
                        "Coordenador",
                        "Tipo Coordenador",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },

                });

            migrationBuilder.CreateTable(
                name: "RecadoStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecadoStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RecadoStatus",
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
                        1,
                        "Enviado",
                        "O recado foi enviado",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        2,
                        "Pendente",
                        "O recado está pendente",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        3,
                        "Cancelado",
                        "O recado foi cancelado",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },

                });

            migrationBuilder.CreateTable(
                name: "RecadoTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecadoTipo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RecadoTipo",
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
                        1,
                        "Normal",
                        "Recado normal",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        2,
                        "Autorização",
                        "Recado que necessita de autorização",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },

                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Periodo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[]
                {
                    "Id",
                    "Nome",
                    "Descricao",
                    "Periodo",
                    "CreatedAt",
                    "UpdatedAt"
                },
                values: new object[,]
                {
                    {
                        1,
                        "1A",
                        "Primeiro A",
                        "Manhã",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        2,
                        "1B",
                        "Primeiro B",
                        "Tarde",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        3,
                        "1C",
                        "Primeiro C",
                        "Noite",
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },

                });

            migrationBuilder.CreateTable(
                name: "Recado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mensagem = table.Column<string>(type: "text", nullable: true),
                    RecadoTipoId = table.Column<int>(type: "integer", nullable: false),
                    RecadoStatusId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recado_RecadoStatus_RecadoStatusId",
                        column: x => x.RecadoStatusId,
                        principalTable: "RecadoStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recado_RecadoTipo_RecadoTipoId",
                        column: x => x.RecadoTipoId,
                        principalTable: "RecadoTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PessoaTipoId = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Sexo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DocumentoTipoId = table.Column<int>(type: "integer", nullable: false),
                    Documento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TurmaId = table.Column<int>(type: "integer", nullable: true),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoa_PessoaTipo_PessoaTipoId",
                        column: x => x.PessoaTipoId,
                        principalTable: "PessoaTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoa_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "Id");
                });

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
                    "TurmaId",
                    "CreatedAt",
                    "UpdatedAt"
                },
                values: new object[,]
                {
                    {
                        1,
                        1,
                        "Aluno1",
                        "Silva",
                        DateTime.Parse("1994-05-02 13:16:34.115").ToUniversalTime(),
                        "Maculino",
                        1,
                        "123456789",
                        1,
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        2,
                        1,
                        "Aluno2",
                        "Souza",
                        DateTime.Parse("1995-05-02 13:16:34.115").ToUniversalTime(),
                        "Feminino",
                        1,
                        "987654321",
                        2,
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        3,
                        2,
                        "Professor1",
                        "Oliveira",
                        DateTime.Parse("1985-02-07 13:16:34.115").ToUniversalTime(),
                        "Maculino",
                        2,
                        "78945623125",
                        null,
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        4,
                        2,
                        "Professor2",
                        "Cardoso",
                        DateTime.Parse("1980-01-08 13:16:34.115").ToUniversalTime(),
                        "Feminino",
                        2,
                        "78941563125",
                        null,
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        5,
                        3,
                        "Coordenador1",
                        "Silva",
                        DateTime.Parse("1981-10-08 13:16:34.115").ToUniversalTime(),
                        "Masculino",
                        3,
                        "354741265",
                        null,
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },
                    {
                        6,
                        3,
                        "Coordenador2",
                        "Cardoso",
                        DateTime.Parse("1980-06-25 13:16:34.115").ToUniversalTime(),
                        "Feminino",
                        3,
                        "1295447856",
                        null,
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    },

                });

            migrationBuilder.CreateTable(
                name: "PessoaRecado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PessoaId = table.Column<int>(type: "integer", nullable: false),
                    RecadoId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaRecado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaRecado_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaRecado_Recado_RecadoId",
                        column: x => x.RecadoId,
                        principalTable: "Recado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    PessoaId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoTipo_Nome",
                table: "DocumentoTipo",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Documento",
                table: "Pessoa",
                column: "Documento",
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
                name: "IX_Pessoa_TurmaId",
                table: "Pessoa",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaRecado_PessoaId",
                table: "PessoaRecado",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaRecado_RecadoId",
                table: "PessoaRecado",
                column: "RecadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaTipo_Nome",
                table: "PessoaTipo",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recado_RecadoStatusId",
                table: "Recado",
                column: "RecadoStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Recado_RecadoTipoId",
                table: "Recado",
                column: "RecadoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PessoaId",
                table: "Usuario",
                column: "PessoaId",
                unique: true);

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[]
                {
                    "Id",
                    "Email",
                    "PasswordHash",
                    "IsAdmin",
                    "PessoaId",
                    "CreatedAt",
                    "UpdatedAt"
                },
                values: new object[,]
                {
                    {
                        1,
                        "fnd.gomes02@gmail.com",
                        "$2a$10$CXkhT338e3Fm/Jv3OPeDWO1.dPJw70.WrrUNIKDnR8pxeRLWWWL0W",
                        true,
                        null,
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                    }

                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaRecado");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Recado");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "RecadoStatus");

            migrationBuilder.DropTable(
                name: "RecadoTipo");

            migrationBuilder.DropTable(
                name: "DocumentoTipo");

            migrationBuilder.DropTable(
                name: "PessoaTipo");

            migrationBuilder.DropTable(
                name: "Turma");
        }
    }
}
