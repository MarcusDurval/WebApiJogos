using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Web.Api.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biblioteca_Jogos",
                columns: table => new
                {
                    ID_Jogo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteca_Jogos", x => x.ID_Jogo);
                });

            migrationBuilder.CreateTable(
                name: "Categoria_Jogos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JogoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria_Jogos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categoria_Jogos_Biblioteca_Jogos_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Biblioteca_Jogos",
                        principalColumn: "ID_Jogo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Jogos_JogoId",
                table: "Categoria_Jogos",
                column: "JogoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria_Jogos");

            migrationBuilder.DropTable(
                name: "Biblioteca_Jogos");
        }
    }
}
