using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWorkDemo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamLeagueId",
                table: "Teams",
                column: "TeamLeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Leagues_TeamLeagueId",
                table: "Teams",
                column: "TeamLeagueId",
                principalTable: "Leagues",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Leagues_TeamLeagueId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeamLeagueId",
                table: "Teams");
        }
    }
}
