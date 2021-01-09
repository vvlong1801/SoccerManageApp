using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoccerManageApp.Migrations
{
    public partial class Initial_update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_match_team_awayresteam_id",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_match_team_homeresteam_id",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_player_team_team_id",
                table: "player");

            migrationBuilder.DropForeignKey(
                name: "FK_score_team_team_id",
                table: "score");

            migrationBuilder.DropForeignKey(
                name: "FK_team_result_team_team_id",
                table: "team_result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_team_result",
                table: "team_result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_team",
                table: "team");

            migrationBuilder.DropIndex(
                name: "IX_score_team_id",
                table: "score");

            migrationBuilder.DropIndex(
                name: "IX_player_team_id",
                table: "player");

            migrationBuilder.DropIndex(
                name: "IX_match_awayresteam_id",
                table: "match");

            migrationBuilder.DropIndex(
                name: "IX_match_homeresteam_id",
                table: "match");

            migrationBuilder.DropColumn(
                name: "team_id",
                table: "team_result");

            migrationBuilder.DropColumn(
                name: "team_id",
                table: "team");

            migrationBuilder.AddColumn<string>(
                name: "team_name",
                table: "team_result",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "score",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "player",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AwayResTeamName",
                table: "match",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeResTeamName",
                table: "match",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_team_result",
                table: "team_result",
                column: "team_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_team",
                table: "team",
                column: "team_name");

            migrationBuilder.CreateIndex(
                name: "IX_score_TeamName",
                table: "score",
                column: "TeamName");

            migrationBuilder.CreateIndex(
                name: "IX_player_TeamName",
                table: "player",
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

            migrationBuilder.AddForeignKey(
                name: "FK_team_result_team_team_name",
                table: "team_result",
                column: "team_name",
                principalTable: "team",
                principalColumn: "team_name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_team_result_team_team_name",
                table: "team_result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_team_result",
                table: "team_result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_team",
                table: "team");

            migrationBuilder.DropIndex(
                name: "IX_score_TeamName",
                table: "score");

            migrationBuilder.DropIndex(
                name: "IX_player_TeamName",
                table: "player");

            migrationBuilder.DropIndex(
                name: "IX_match_AwayResTeamName",
                table: "match");

            migrationBuilder.DropIndex(
                name: "IX_match_HomeResTeamName",
                table: "match");

            migrationBuilder.DropColumn(
                name: "team_name",
                table: "team_result");

            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "score");

            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "player");

            migrationBuilder.DropColumn(
                name: "AwayResTeamName",
                table: "match");

            migrationBuilder.DropColumn(
                name: "HomeResTeamName",
                table: "match");

            migrationBuilder.AddColumn<int>(
                name: "team_id",
                table: "team_result",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "team_id",
                table: "team",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_team_result",
                table: "team_result",
                column: "team_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_team",
                table: "team",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_score_team_id",
                table: "score",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_team_id",
                table: "player",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_awayresteam_id",
                table: "match",
                column: "awayresteam_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_homeresteam_id",
                table: "match",
                column: "homeresteam_id");

            migrationBuilder.AddForeignKey(
                name: "FK_match_team_awayresteam_id",
                table: "match",
                column: "awayresteam_id",
                principalTable: "team",
                principalColumn: "team_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_match_team_homeresteam_id",
                table: "match",
                column: "homeresteam_id",
                principalTable: "team",
                principalColumn: "team_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_player_team_team_id",
                table: "player",
                column: "team_id",
                principalTable: "team",
                principalColumn: "team_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_score_team_team_id",
                table: "score",
                column: "team_id",
                principalTable: "team",
                principalColumn: "team_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_team_result_team_team_id",
                table: "team_result",
                column: "team_id",
                principalTable: "team",
                principalColumn: "team_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
