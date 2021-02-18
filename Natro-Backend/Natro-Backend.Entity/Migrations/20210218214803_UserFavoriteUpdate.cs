using Microsoft.EntityFrameworkCore.Migrations;

namespace Natro_Backend.Entity.Migrations
{
    public partial class UserFavoriteUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailableToBuy",
                table: "UserFavorites",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailableToBuy",
                table: "UserFavorites");
        }
    }
}
