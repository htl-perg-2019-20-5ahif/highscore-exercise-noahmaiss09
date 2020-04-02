using Microsoft.EntityFrameworkCore.Migrations;

namespace Highscore_Back_End2.Migrations
{
    public partial class standardScoreList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HighscoreLists",
                column: "HighscoreListId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HighscoreLists",
                keyColumn: "HighscoreListId",
                keyValue: 1);
        }
    }
}
