using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Casa_Criancas.Migrations
{
    /// <inheritdoc />
    public partial class AAAAAAAA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssistentesSociais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistentesSociais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HorarioDasAulas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaDaSemana = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Abreviacao = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    HoraInicio = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    HoraFim = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioDasAulas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatriculaAnoMes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ano = table.Column<int>(type: "int", nullable: false),
                    mes = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatriculaAnoMes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MatriculaGrp",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aluno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    turma = table.Column<int>(type: "int", nullable: false),
                    qtdeAluno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatriculaGrp", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Monitores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PivotMatricula",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ano = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    janeiro = table.Column<float>(type: "real", nullable: false),
                    fevereiro = table.Column<float>(type: "real", nullable: false),
                    marco = table.Column<float>(type: "real", nullable: false),
                    abril = table.Column<float>(type: "real", nullable: false),
                    maio = table.Column<float>(type: "real", nullable: false),
                    junho = table.Column<float>(type: "real", nullable: false),
                    julho = table.Column<float>(type: "real", nullable: false),
                    agosto = table.Column<float>(type: "real", nullable: false),
                    setembro = table.Column<float>(type: "real", nullable: false),
                    outubro = table.Column<float>(type: "real", nullable: false),
                    novembro = table.Column<float>(type: "real", nullable: false),
                    dezembro = table.Column<float>(type: "real", nullable: false),
                    total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PivotMatricula", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TurmaGrp",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    curso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    colaborador = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaGrp", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    colaboradorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Colaboradores_colaboradorID",
                        column: x => x.colaboradorID,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    responsavelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Responsaveis_responsavelID",
                        column: x => x.responsavelID,
                        principalTable: "Responsaveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cursoId = table.Column<int>(type: "int", nullable: false),
                    monitorId = table.Column<int>(type: "int", nullable: false),
                    professorId = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    horarioDasAulasID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Cursos_cursoId",
                        column: x => x.cursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turmas_HorarioDasAulas_horarioDasAulasID",
                        column: x => x.horarioDasAulasID,
                        principalTable: "HorarioDasAulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turmas_Monitores_monitorId",
                        column: x => x.monitorId,
                        principalTable: "Monitores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turmas_Professores_professorId",
                        column: x => x.professorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alunoID = table.Column<int>(type: "int", nullable: false),
                    assistenteSocialID = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    situacaoFamiliar = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    acoesPreliminares = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    contextoExterno = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    contextoFamiliar = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    redeApoio = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    violacaoDireito = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    encaminhamento = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    compactacoes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    escolarizacao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    violenciaDomestica = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitas_Alunos_alunoID",
                        column: x => x.alunoID,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitas_AssistentesSociais_assistenteSocialID",
                        column: x => x.assistenteSocialID,
                        principalTable: "AssistentesSociais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alunoID = table.Column<int>(type: "int", nullable: false),
                    turmaID = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matriculas_Alunos_alunoID",
                        column: x => x.alunoID,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matriculas_Turmas_turmaID",
                        column: x => x.turmaID,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chamadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    matriculaID = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chamadas_Matriculas_matriculaID",
                        column: x => x.matriculaID,
                        principalTable: "Matriculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_responsavelID",
                table: "Alunos",
                column: "responsavelID");

            migrationBuilder.CreateIndex(
                name: "IX_Chamadas_matriculaID",
                table: "Chamadas",
                column: "matriculaID");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_colaboradorID",
                table: "Cursos",
                column: "colaboradorID");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_alunoID",
                table: "Matriculas",
                column: "alunoID");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_turmaID",
                table: "Matriculas",
                column: "turmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_cursoId",
                table: "Turmas",
                column: "cursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_horarioDasAulasID",
                table: "Turmas",
                column: "horarioDasAulasID");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_monitorId",
                table: "Turmas",
                column: "monitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_professorId",
                table: "Turmas",
                column: "professorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_alunoID",
                table: "Visitas",
                column: "alunoID");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_assistenteSocialID",
                table: "Visitas",
                column: "assistenteSocialID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chamadas");

            migrationBuilder.DropTable(
                name: "MatriculaAnoMes");

            migrationBuilder.DropTable(
                name: "MatriculaGrp");

            migrationBuilder.DropTable(
                name: "PivotMatricula");

            migrationBuilder.DropTable(
                name: "TurmaGrp");

            migrationBuilder.DropTable(
                name: "Visitas");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "AssistentesSociais");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "HorarioDasAulas");

            migrationBuilder.DropTable(
                name: "Monitores");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Colaboradores");
        }
    }
}
