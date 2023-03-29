using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieProject.Migrations
{
    public partial class addeddirectorentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "PosterUrl",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "RuntimeMinutes",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.MovieId, x.DirectorId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_DirectorId",
                table: "MovieActors",
                column: "DirectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterUrl",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RuntimeMinutes",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
