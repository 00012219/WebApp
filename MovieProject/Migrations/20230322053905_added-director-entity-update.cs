using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieProject.Migrations
{
    public partial class addeddirectorentityupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Actors_DirectorId",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Movies_MovieId",
                table: "MovieActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieActors",
                table: "MovieActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.RenameTable(
                name: "MovieActors",
                newName: "MovieDirectors");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "Directors");

            migrationBuilder.RenameIndex(
                name: "IX_MovieActors_DirectorId",
                table: "MovieDirectors",
                newName: "IX_MovieDirectors_DirectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieDirectors",
                table: "MovieDirectors",
                columns: new[] { "MovieId", "DirectorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorId",
                table: "MovieDirectors",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Movies_MovieId",
                table: "MovieDirectors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorId",
                table: "MovieDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Movies_MovieId",
                table: "MovieDirectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieDirectors",
                table: "MovieDirectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.RenameTable(
                name: "MovieDirectors",
                newName: "MovieActors");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "Actors");

            migrationBuilder.RenameIndex(
                name: "IX_MovieDirectors_DirectorId",
                table: "MovieActors",
                newName: "IX_MovieActors_DirectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieActors",
                table: "MovieActors",
                columns: new[] { "MovieId", "DirectorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Actors_DirectorId",
                table: "MovieActors",
                column: "DirectorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Movies_MovieId",
                table: "MovieActors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
