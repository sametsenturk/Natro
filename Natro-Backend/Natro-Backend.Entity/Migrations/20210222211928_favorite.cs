using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Natro_Backend.Entity.Migrations
{
    public partial class favorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "UserFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChange",
                table: "UserFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nameserver1",
                table: "UserFavorites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nameserver2",
                table: "UserFavorites",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "UserFavorites");

            migrationBuilder.DropColumn(
                name: "LastChange",
                table: "UserFavorites");

            migrationBuilder.DropColumn(
                name: "Nameserver1",
                table: "UserFavorites");

            migrationBuilder.DropColumn(
                name: "Nameserver2",
                table: "UserFavorites");
        }
    }
}
