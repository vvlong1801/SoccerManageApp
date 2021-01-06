using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoccerManageApp.Migrations
{
    public partial class Initial_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stadium",
                columns: table => new
                {
                    stadium_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stadium_name = table.Column<string>(maxLength: 30, nullable: false),
                    capacity = table.Column<int>(nullable: false),
                    city = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stadium", x => x.stadium_id);
                });

            migrationBuilder.CreateTable(
                name: "team",
                columns: table => new
                {
                    team_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    team_name = table.Column<string>(maxLength: 30, nullable: false),
                    team_image = table.Column<string>(maxLength: 30, nullable: false),
                    StadiumID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team", x => x.team_id);
                    table.ForeignKey(
                        name: "FK_team_stadium_StadiumID",
                        column: x => x.StadiumID,
                        principalTable: "stadium",
                        principalColumn: "stadium_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "match",
                columns: table => new
                {
                    match_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datetime = table.Column<DateTime>(nullable: false),
                    attendance = table.Column<int>(nullable: false),
                    homeresteam_id = table.Column<int>(nullable: false),
                    awayresteam_id = table.Column<int>(nullable: false),
                    stadium_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_match", x => x.match_id);
                    table.ForeignKey(
                        name: "FK_match_team_awayresteam_id",
                        column: x => x.awayresteam_id,
                        principalTable: "team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_match_team_homeresteam_id",
                        column: x => x.homeresteam_id,
                        principalTable: "team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_match_stadium_stadium_id",
                        column: x => x.stadium_id,
                        principalTable: "stadium",
                        principalColumn: "stadium_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    player_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(maxLength: 30, nullable: false),
                    last_name = table.Column<string>(maxLength: 30, nullable: false),
                    kit = table.Column<int>(nullable: false),
                    position = table.Column<string>(maxLength: 30, nullable: true),
                    country_image = table.Column<string>(maxLength: 30, nullable: true),
                    CountryImage = table.Column<string>(nullable: true),
                    team_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.player_id);
                    table.ForeignKey(
                        name: "FK_player_team_team_id",
                        column: x => x.team_id,
                        principalTable: "team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamResult",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WinMatch = table.Column<int>(nullable: false),
                    DrawMatch = table.Column<int>(nullable: false),
                    LoseMatch = table.Column<int>(nullable: false),
                    Point = table.Column<int>(nullable: false),
                    TeamID1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamResult", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_TeamResult_team_TeamID1",
                        column: x => x.TeamID1,
                        principalTable: "team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "result",
                columns: table => new
                {
                    match_id = table.Column<int>(nullable: false),
                    home_res = table.Column<int>(nullable: false),
                    away_res = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_result", x => x.match_id);
                    table.ForeignKey(
                        name: "FK_result_match_match_id",
                        column: x => x.match_id,
                        principalTable: "match",
                        principalColumn: "match_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "score",
                columns: table => new
                {
                    score_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    match_id = table.Column<int>(nullable: false),
                    player_id = table.Column<int>(nullable: false),
                    team_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_score", x => x.score_id);
                    table.ForeignKey(
                        name: "FK_score_match_match_id",
                        column: x => x.match_id,
                        principalTable: "match",
                        principalColumn: "match_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_score_player_player_id",
                        column: x => x.player_id,
                        principalTable: "player",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_score_team_team_id",
                        column: x => x.team_id,
                        principalTable: "team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_match_awayresteam_id",
                table: "match",
                column: "awayresteam_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_homeresteam_id",
                table: "match",
                column: "homeresteam_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_stadium_id",
                table: "match",
                column: "stadium_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_team_id",
                table: "player",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_score_match_id",
                table: "score",
                column: "match_id");

            migrationBuilder.CreateIndex(
                name: "IX_score_player_id",
                table: "score",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_score_team_id",
                table: "score",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_team_StadiumID",
                table: "team",
                column: "StadiumID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamResult_TeamID1",
                table: "TeamResult",
                column: "TeamID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "result");

            migrationBuilder.DropTable(
                name: "score");

            migrationBuilder.DropTable(
                name: "TeamResult");

            migrationBuilder.DropTable(
                name: "match");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropTable(
                name: "team");

            migrationBuilder.DropTable(
                name: "stadium");
        }
    }
}
