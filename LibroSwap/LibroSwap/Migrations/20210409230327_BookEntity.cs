using Microsoft.EntityFrameworkCore.Migrations;

namespace LibroSwap.Migrations
{
    public partial class BookEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    current_owner_id = table.Column<int>(type: "int", nullable: false),
                    genre_id = table.Column<int>(type: "int", nullable: false),
                    secondary_genre_id = table.Column<int>(type: "int", nullable: true),
                    tertiary_genre_id = table.Column<int>(type: "int", nullable: true),
                    language_id = table.Column<int>(type: "int", nullable: false),
                    book_coverage_id = table.Column<int>(type: "int", nullable: false),
                    bookhouse_id = table.Column<int>(type: "int", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    translator_id = table.Column<int>(type: "int", nullable: true),
                    Translation = table.Column<bool>(type: "bit", nullable: false),
                    Pages = table.Column<long>(type: "bigint", nullable: false),
                    Year = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_author_id",
                        column: x => x.author_id,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Authors_translator_id",
                        column: x => x.translator_id,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Bookhouses_bookhouse_id",
                        column: x => x.bookhouse_id,
                        principalTable: "Bookhouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Cities_city_id",
                        column: x => x.city_id,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_Coverages_book_coverage_id",
                        column: x => x.book_coverage_id,
                        principalTable: "Coverages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_secondary_genre_id",
                        column: x => x.secondary_genre_id,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Genres_tertiary_genre_id",
                        column: x => x.tertiary_genre_id,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Languages_language_id",
                        column: x => x.language_id,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Users_current_owner_id",
                        column: x => x.current_owner_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "book_coverage_id", "bookhouse_id", "city_id", "current_owner_id", "genre_id", "language_id", "Pages", "secondary_genre_id", "tertiary_genre_id", "title", "Translation", "translator_id", "Year" },
                values: new object[] { 1, 1, 1, 1, 4, 4, 1, 1, 829L, null, null, "Амадока", false, null, 2020L });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "book_coverage_id", "bookhouse_id", "city_id", "current_owner_id", "genre_id", "language_id", "Pages", "secondary_genre_id", "tertiary_genre_id", "title", "Translation", "translator_id", "Year" },
                values: new object[] { 2, 5, 1, 2, 1, 2, 1, 1, 815L, null, null, "Гаррі Поттер і Орден Фенікса", true, 1, 2003L });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "book_coverage_id", "bookhouse_id", "city_id", "current_owner_id", "genre_id", "language_id", "Pages", "secondary_genre_id", "tertiary_genre_id", "title", "Translation", "translator_id", "Year" },
                values: new object[] { 3, 5, 2, 3, 2, 1, 1, 2, 766L, null, null, "Harry Potter and the Order of the Phoenix", false, null, 2003L });

            migrationBuilder.CreateIndex(
                name: "IX_Books_author_id",
                table: "Books",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_book_coverage_id",
                table: "Books",
                column: "book_coverage_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_bookhouse_id",
                table: "Books",
                column: "bookhouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_city_id",
                table: "Books",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_current_owner_id",
                table: "Books",
                column: "current_owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_genre_id",
                table: "Books",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_language_id",
                table: "Books",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_secondary_genre_id",
                table: "Books",
                column: "secondary_genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_tertiary_genre_id",
                table: "Books",
                column: "tertiary_genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_translator_id",
                table: "Books",
                column: "translator_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
