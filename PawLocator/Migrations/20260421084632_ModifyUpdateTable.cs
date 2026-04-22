using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawLocator.Migrations
{
    public partial class ModifyUpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Updates");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Updates");

            migrationBuilder.DropColumn(
                name: "PostType",
                table: "Updates");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Updates");

            migrationBuilder.DropColumn(
                name: "PostType",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Updates",
                newName: "Message");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Updates",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Updates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Updates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostType",
                table: "Updates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Updates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostType",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
