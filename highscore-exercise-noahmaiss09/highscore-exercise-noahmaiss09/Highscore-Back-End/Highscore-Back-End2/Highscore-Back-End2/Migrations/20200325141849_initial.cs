using Microsoft.EntityFrameworkCore.Migrations;

namespace Highscore_Back_End2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HighscoreLists",
                columns: table => new
                {
                    HighscoreListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighscoreLists", x => x.HighscoreListId);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    ScoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    HighsoreListId = table.Column<int>(nullable: false),
                    HighscoreListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.ScoreId);
                    table.ForeignKey(
                        name: "FK_Scores_HighscoreLists_HighscoreListId",
                        column: x => x.HighscoreListId,
                        principalTable: "HighscoreLists",
                        principalColumn: "HighscoreListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scores_HighscoreListId",
                table: "Scores",
                column: "HighscoreListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "HighscoreLists");
        }
    }
}
