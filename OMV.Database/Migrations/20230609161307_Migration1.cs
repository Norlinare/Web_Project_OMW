using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OMV.Video.Database.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Free = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilmUrl = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmGenres",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenres", x => new { x.GenreId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_FilmGenres_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilmGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SimilarFilms",
                columns: table => new
                {
                    ParentFilmId = table.Column<int>(type: "int", nullable: false),
                    SimilarFilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimilarFilms", x => new { x.ParentFilmId, x.SimilarFilmId });
                    table.ForeignKey(
                        name: "FK_SimilarFilms_Films_ParentFilmId",
                        column: x => x.ParentFilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SimilarFilms_Films_SimilarFilmId",
                        column: x => x.SimilarFilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Steven Spielberg" },
                    { 2, "Clint Eastwood" },
                    { 3, "Tim Burton" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adventure" },
                    { 2, "Sci-Fi" },
                    { 3, "Horror" },
                    { 4, "Western" },
                    { 5, "Sport" },
                    { 6, "Action" },
                    { 7, "Mystery" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "DirectorId", "FilmUrl", "Free", "Released", "Title" },
                values: new object[,]
                {
                    { 1, "An adventurer goes looking for the Crystal Skull in a temple.", 1, "https://www.youtube.com/watch?v=WAdJf4wTC5Y", false, new DateTime(2008, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indiana Jones and the Kingdom of the Crystal Skull" },
                    { 2, "Dinosaurs get released by accident on an amusement park and wreck havoc.", 1, "https://www.youtube.com/watch?v=lc0UehYemQA", false, new DateTime(1993, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurassic Park" },
                    { 3, "A shark attacks people at a beach.", 1, "https://www.youtube.com/watch?v=U1fu_sA7XhE", true, new DateTime(1975, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaws" },
                    { 4, "A story in space.", 2, "https://www.youtube.com/watch?v=WjIMiGb_tmM", true, new DateTime(2000, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Space Cowboys" },
                    { 5, "A western story about a man.", 2, "https://www.youtube.com/watch?v=SGzz3hh1jHc", true, new DateTime(1985, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pale Rider" },
                    { 6, "A story about a sports player in South Africa.", 2, "https://www.youtube.com/watch?v=RZY8c_a_dlQ", false, new DateTime(2009, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Invictus" },
                    { 7, "A boy's parents gets murdered and the son take an oath to avenge them and fight off evil.", 3, "https://www.youtube.com/watch?v=dgC9Q0uhX70", true, new DateTime(1989, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman" },
                    { 8, "Alice falls down a hole and has to save a kingdom.", 3, "https://www.youtube.com/watch?v=9POCgSRVvf0", false, new DateTime(2010, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice in Wonderland" },
                    { 9, "A boy finds a mysterious house with mysterious people.", 3, "https://www.youtube.com/watch?v=tV_IhWE4LP0", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2016), "Miss Peregrine's Home for Peculiar Children" }
                });

            migrationBuilder.InsertData(
                table: "FilmGenres",
                columns: new[] { "FilmId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 8, 1 },
                    { 2, 2 },
                    { 4, 2 },
                    { 3, 3 },
                    { 5, 4 },
                    { 6, 5 },
                    { 7, 6 },
                    { 9, 7 }
                });

            migrationBuilder.InsertData(
                table: "SimilarFilms",
                columns: new[] { "ParentFilmId", "SimilarFilmId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 8 },
                    { 2, 1 },
                    { 4, 5 },
                    { 5, 4 },
                    { 5, 7 },
                    { 7, 5 },
                    { 8, 1 },
                    { 8, 9 },
                    { 9, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenres_FilmId",
                table: "FilmGenres",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_DirectorId",
                table: "Films",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarFilms_SimilarFilmId",
                table: "SimilarFilms",
                column: "SimilarFilmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGenres");

            migrationBuilder.DropTable(
                name: "SimilarFilms");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
