using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Casa_Criancas.Migrations
{
    /// <inheritdoc />
    public partial class PivotMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "Chamadas",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatriculaAnoMes");

            migrationBuilder.DropTable(
                name: "MatriculaGrp");

            migrationBuilder.DropTable(
                name: "PivotMatricula");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "Chamadas",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
