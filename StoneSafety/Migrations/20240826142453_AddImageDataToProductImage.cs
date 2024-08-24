using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoneSafety.Migrations
{
    public partial class AddImageDataToProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "ProductImages",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "ProductImages");
        }
    }
}
