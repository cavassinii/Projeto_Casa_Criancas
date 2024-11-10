using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Casa_Criancas.Migrations
{
    /// <inheritdoc />
    public partial class nova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitas_AssistentesSociais_assistenteSocialId",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "assistenteID",
                table: "Visitas");

            migrationBuilder.RenameColumn(
                name: "assistenteSocialId",
                table: "Visitas",
                newName: "assistenteSocialID");

            migrationBuilder.RenameIndex(
                name: "IX_Visitas_assistenteSocialId",
                table: "Visitas",
                newName: "IX_Visitas_assistenteSocialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_AssistentesSociais_assistenteSocialID",
                table: "Visitas",
                column: "assistenteSocialID",
                principalTable: "AssistentesSociais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitas_AssistentesSociais_assistenteSocialID",
                table: "Visitas");

            migrationBuilder.RenameColumn(
                name: "assistenteSocialID",
                table: "Visitas",
                newName: "assistenteSocialId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitas_assistenteSocialID",
                table: "Visitas",
                newName: "IX_Visitas_assistenteSocialId");

            migrationBuilder.AddColumn<int>(
                name: "assistenteID",
                table: "Visitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_AssistentesSociais_assistenteSocialId",
                table: "Visitas",
                column: "assistenteSocialId",
                principalTable: "AssistentesSociais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
