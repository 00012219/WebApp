using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieProject.Migrations
{
    public partial class changeddirectorfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Directors");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Directors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Email",
                table: "Directors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstName",
                table: "Directors",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastName",
                table: "Directors",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Directors");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
