using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerManageApp.Migrations
{
    public partial class Initial_update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryImage",
                table: "player");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "player",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "country",
                table: "player");

            migrationBuilder.AddColumn<string>(
                name: "CountryImage",
                table: "player",
                type: "text",
                nullable: true);
        }
    }
}
