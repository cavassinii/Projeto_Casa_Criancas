using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Casa_Criancas.Migrations
{
    /// <inheritdoc />
    public partial class TurmaGrp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurmaGrp");
        }
    }
}
