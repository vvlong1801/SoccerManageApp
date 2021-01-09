using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerManageApp.Migrations
{
    public partial class Initial_update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_match_team_AwayResTeamName",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_match_team_HomeResTeamName",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_player_team_TeamName",
                table: "player");

            migrationBuilder.DropForeignKey(
                name: "FK_score_team_TeamName",
                table: "score");

            migrationBuilder.DropIndex(
                name: "IX_score_TeamName",
                table: "score");

            migrationBuilder.DropIndex(
                name: "IX_match_AwayResTeamName",
                table: "match");

            migrationBuilder.DropIndex(
                name: "IX_match_HomeResTeamName",
                table: "match");

            migrationBuilder.DropColumn(
                name: "team_id",
                table: "score");

            migrationBuilder.DropColumn(
                name: "team_id",
                table: "player");

            migrationBuilder.DropColumn(
                name: "awayresteam_id",
                table: "match");

            migrationBuilder.DropColumn(
                name: "AwayResTeamName",
                table: "match");

            migrationBuilder.DropColumn(
                name: "homeresteam_id",
                table: "match");

            migrationBuilder.DropColumn(
                name: "HomeResTeamName",
                table: "match");

            migrationBuilder.RenameColumn(
                name: "TeamName",
                table: "score",
                newName: "team_name");

            migrationBuilder.RenameColumn(
                name: "TeamName",
                table: "player",
                newName: "team_name");

            migrationBuilder.RenameIndex(
                name: "IX_player_TeamName",
                table: "player",
                newName: "IX_player_team_name");

            migrationBuilder.AddColumn<string>(
                name: "TeamName1",
                table: "score",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "awayteam_name",
                table: "match",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "hometeam_name",
                table: "match",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_score_TeamName1",
                table: "score",
                column: "TeamName1");

            migrationBuilder.CreateIndex(
                name: "IX_match_awayteam_name",
                table: "match",
                column: "awayteam_name");

            migrationBuilder.CreateIndex(
                name: "IX_match_hometeam_name",
                table: "match",
                column: "hometeam_name");

            migrationBuilder.AddForeignKey(
                name: "FK_match_team_awayteam_name",
                table: "match",
                column: "awayteam_name",
                principalTable: "team",
                principalColumn: "team_name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_match_team_hometeam_name",
                table: "match",
                column: "hometeam_name",
                principalTable: "team",
                principalColumn: "team_name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_player_team_team_name",
                table: "player",
                column: "team_name",
                principalTable: "team",
                principalColumn: "team_name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_score_team_TeamName1",
                table: "score",
                column: "TeamName1",
                principalTable: "team",
                principalColumn: "team_name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_match_team_awayteam_name",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_match_team_hometeam_name",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_player_team_team_name",
                table: "player");

            migrationBuilder.DropForeignKey(
                name: "FK_score_team_TeamName1",
                table: "score");

            migrationBuilder.DropIndex(
                name: "IX_score_TeamName1",
                table: "score");

            migrationBuilder.DropIndex(
                name: "IX_match_awayteam_name",
                table: "match");

            migrationBuilder.DropIndex(
                name: "IX_match_hometeam_name",
                table: "match");

            migrationBuilder.DropColumn(
                name: "TeamName1",
                table: "score");

            migrationBuilder.DropColumn(
                name: "awayteam_name",
                table: "match");

            migrationBuilder.DropColumn(
                name: "hometeam_name",
                table: "match");

            migrationBuilder.RenameColumn(
                name: "team_name",
                table: "score",
                newName: "TeamName");

            migrationBuilder.RenameColumn(
                name: "team_name",
                table: "player",
                newName: "TeamName");

            migrationBuilder.RenameIndex(
                name: "IX_player_team_name",
                table: "player",
                newName: "IX_player_TeamName");

            migrationBuilder.AddColumn<int>(
                name: "team_id",
                table: "score",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "team_id",
                table: "player",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "awayresteam_id",
                table: "match",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AwayResTeamName",
                table: "match",
                type: "character varying(30)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "homeresteam_id",
                table: "match",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HomeResTeamName",
                table: "match",
                type: "character varying(30)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_score_TeamName",
                table: "score",
                column: "TeamName");

            migrationBuilder.CreateIndex(
                name: "IX_match_AwayResTeamName",
                table: "match",
                column: "AwayResTeamName");

            migrationBuilder.CreateIndex(
                name: "IX_match_HomeResTeamName",
                table: "match",
                column: "HomeResTeamName");

            migrationBuilder.AddForeignKey(
                name: "FK_match_team_AwayResTeamName",
                table: "match",
                column: "AwayResTeamName",
                principalTable: "team",
                principalColumn: "team_name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_match_team_HomeResTeamName",
                table: "match",
                column: "HomeResTeamName",
                principalTable: "team",
                principalColumn: "team_name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_player_team_TeamName",
                table: "player",
                column: "TeamName",
                principalTable: "team",
                principalColumn: "team_name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_score_team_TeamName",
                table: "score",
                column: "TeamName",
                principalTable: "team",
                principalColumn: "team_name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
