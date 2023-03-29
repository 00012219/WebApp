using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieProject.Migrations
{
    public partial class removeddirectorsfieldfrommoviemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Movies_MovieId",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Directors_MovieId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Directors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Directors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Directors_MovieId",
                table: "Directors",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Movies_MovieId",
                table: "Directors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
