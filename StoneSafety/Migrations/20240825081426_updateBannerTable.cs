using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoneSafety.Migrations
{
    public partial class updateBannerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Banners");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Banners",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Banners",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Banners");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Banners",
                newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
