using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Casa_Criancas.Migrations
{
    /// <inheritdoc />
    public partial class ColaboradorGrp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColaboradorGrp",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    colaboradorNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cursoNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cursoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorGrp", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColaboradorGrp");
        }
    }
}
