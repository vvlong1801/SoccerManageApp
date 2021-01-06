using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoccerManageApp.Migrations
{
    public partial class Initial_update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamResult_team_TeamID1",
                table: "TeamResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamResult",
                table: "TeamResult");

            migrationBuilder.DropIndex(
                name: "IX_TeamResult_TeamID1",
                table: "TeamResult");

            migrationBuilder.DropColumn(
                name: "TeamID1",
                table: "TeamResult");

            migrationBuilder.RenameTable(
                name: "TeamResult",
                newName: "team_result");

            migrationBuilder.RenameColumn(
                name: "Point",
                table: "team_result",
                newName: "point");

            migrationBuilder.RenameColumn(
                name: "WinMatch",
                table: "team_result",
                newName: "win_match");

            migrationBuilder.RenameColumn(
                name: "LoseMatch",
                table: "team_result",
                newName: "lose_match");

            migrationBuilder.RenameColumn(
                name: "DrawMatch",
                table: "team_result",
                newName: "draw_match");

            migrationBuilder.RenameColumn(
                name: "TeamID",
                table: "team_result",
                newName: "team_id");

            migrationBuilder.AlterColumn<int>(
                name: "team_id",
                table: "team_result",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_team_result",
                table: "team_result",
                column: "team_id");

            migrationBuilder.AddForeignKey(
                name: "FK_team_result_team_team_id",
                table: "team_result",
                column: "team_id",
                principalTable: "team",
                principalColumn: "team_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_team_result_team_team_id",
                table: "team_result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_team_result",
                table: "team_result");

            migrationBuilder.RenameTable(
                name: "team_result",
                newName: "TeamResult");

            migrationBuilder.RenameColumn(
                name: "point",
                table: "TeamResult",
                newName: "Point");

            migrationBuilder.RenameColumn(
                name: "win_match",
                table: "TeamResult",
                newName: "WinMatch");

            migrationBuilder.RenameColumn(
                name: "lose_match",
                table: "TeamResult",
                newName: "LoseMatch");

            migrationBuilder.RenameColumn(
                name: "draw_match",
                table: "TeamResult",
                newName: "DrawMatch");

            migrationBuilder.RenameColumn(
                name: "team_id",
                table: "TeamResult",
                newName: "TeamID");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "TeamResult",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "TeamID1",
                table: "TeamResult",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamResult",
                table: "TeamResult",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamResult_TeamID1",
                table: "TeamResult",
                column: "TeamID1");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamResult_team_TeamID1",
                table: "TeamResult",
                column: "TeamID1",
                principalTable: "team",
                principalColumn: "team_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
