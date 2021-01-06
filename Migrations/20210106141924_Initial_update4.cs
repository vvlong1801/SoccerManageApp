using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerManageApp.Migrations
{
    public partial class Initial_update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_team_stadium_StadiumID",
                table: "team");

            migrationBuilder.RenameColumn(
                name: "StadiumID",
                table: "team",
                newName: "stadium_id");

            migrationBuilder.RenameIndex(
                name: "IX_team_StadiumID",
                table: "team",
                newName: "IX_team_stadium_id");

            migrationBuilder.AddForeignKey(
                name: "FK_team_stadium_stadium_id",
                table: "team",
                column: "stadium_id",
                principalTable: "stadium",
                principalColumn: "stadium_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_team_stadium_stadium_id",
                table: "team");

            migrationBuilder.RenameColumn(
                name: "stadium_id",
                table: "team",
                newName: "StadiumID");

            migrationBuilder.RenameIndex(
                name: "IX_team_stadium_id",
                table: "team",
                newName: "IX_team_StadiumID");

            migrationBuilder.AddForeignKey(
                name: "FK_team_stadium_StadiumID",
                table: "team",
                column: "StadiumID",
                principalTable: "stadium",
                principalColumn: "stadium_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
