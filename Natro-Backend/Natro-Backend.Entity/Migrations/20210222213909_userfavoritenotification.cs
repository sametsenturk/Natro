using Microsoft.EntityFrameworkCore.Migrations;

namespace Natro_Backend.Entity.Migrations
{
    public partial class userfavoritenotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFavoriteNotifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFavoriteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteNotifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserFavoriteNotifications_UserFavorites_UserFavoriteID",
                        column: x => x.UserFavoriteID,
                        principalTable: "UserFavorites",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteNotifications_UserFavoriteID",
                table: "UserFavoriteNotifications",
                column: "UserFavoriteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFavoriteNotifications");
        }
    }
}
