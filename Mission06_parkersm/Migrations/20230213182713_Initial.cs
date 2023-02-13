using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission06_parkersm.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movieSubmittals",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: true),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieSubmittals", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "movieSubmittals",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Thriller", "M. Night Shyamalan", false, "", "", "PG-13", "Split", "2016" });

            migrationBuilder.InsertData(
                table: "movieSubmittals",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Adventure", "Ben Stiller", false, "", "", "PG", "The Secret Life of Walter Mitty", "2013" });

            migrationBuilder.InsertData(
                table: "movieSubmittals",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Action", "Joss Whedon", false, "", "", "PG-13", "The Avengers", "2012" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieSubmittals");
        }
    }
}
