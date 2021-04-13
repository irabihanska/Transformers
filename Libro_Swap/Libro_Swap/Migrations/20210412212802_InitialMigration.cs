using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Libro_Swap.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    author_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    author_surname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCoverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coverage_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCoverages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genre_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    language_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    language_code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    country_code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    city_code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_LibCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "LibCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookhouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookhouse_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookhouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookhouses_Cities_city_id",
                        column: x => x.city_id,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    about_me = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    recommendation = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    city_id = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_city_id",
                        column: x => x.city_id,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_Books_BookAuthors_author_id",
                        column: x => x.author_id,
                        principalTable: "BookAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_BookAuthors_translator_id",
                        column: x => x.translator_id,
                        principalTable: "BookAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_BookCoverages_book_coverage_id",
                        column: x => x.book_coverage_id,
                        principalTable: "BookCoverages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "BookAuthors",
                columns: new[] { "Id", "author_name", "author_surname" },
                values: new object[,]
                {
                    { 1, "Софія", "Андрухович" },
                    { 2, "Оксана", "Забужко" },
                    { 3, "Луїза", "Хей" },
                    { 4, "Вадим", "Зеланд" },
                    { 5, "Джоан", "Роулінг" }
                });

            migrationBuilder.InsertData(
                table: "BookCoverages",
                columns: new[] { "Id", "coverage_name" },
                values: new object[,]
                {
                    { 1, "Тверда" },
                    { 2, "М'яка" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "genre_name" },
                values: new object[,]
                {
                    { 1, "Проза" },
                    { 2, "Поезія" },
                    { 3, "Драматургія" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "language_code", "language_name" },
                values: new object[,]
                {
                    { 3, "FRA", "Французька" },
                    { 2, "ENG", "Англійська" },
                    { 4, "CHI", "Китайська" },
                    { 1, "UKR", "Українська" }
                });

            migrationBuilder.InsertData(
                table: "LibCountries",
                columns: new[] { "Id", "country_code", "country_name" },
                values: new object[,]
                {
                    { 3, "SCOT", "Шотландія" },
                    { 2, "EN", "Англія" },
                    { 1, "UA", "Україна" },
                    { 4, "FR", "Франція" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "about_me", "AccessFailedCount", "city_id", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "phone", "PhoneNumber", "PhoneNumberConfirmed", "recommendation", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 3, "Nullam molestie nibh in lectus. Pellentesque at nulla. Suspendisse potenti.", 0, null, "02390099-996a-4757-a5ed-fc938f349d1a", "tcothey1t@gmpg.org", false, null, null, false, null, null, null, null, null, null, false, null, null, false, "Konklab" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "city_code", "city_name", "CountryId" },
                values: new object[,]
                {
                    { 1, "LV", "Львів", 1 },
                    { 2, "KYI", "Київ", 1 },
                    { 3, "LND", "Лондон", 2 },
                    { 4, "PRS", "Париж", 4 }
                });

            migrationBuilder.InsertData(
                table: "Bookhouses",
                columns: new[] { "Id", "bookhouse_name", "city_id" },
                values: new object[,]
                {
                    { 1, "Видавництво Старого Лева", 1 },
                    { 2, "Видавництво Івана Малковича „А-ба-ба-га-ла-ма-га", 2 },
                    { 3, "Bloomsbury", 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "about_me", "AccessFailedCount", "city_id", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "phone", "PhoneNumber", "PhoneNumberConfirmed", "recommendation", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 5, "In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.", 0, 1, "7b0ad8f9-7640-4b30-bdc2-a7f96a73c033", "tshimman1a@wp.com", false, null, null, false, null, null, null, null, null, null, false, null, null, false, "Flowdesk" },
                    { 4, "Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi. Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit.", 0, 2, "d5fac973-e7d3-4fe3-a6c6-e3f1cd98c3c3", "jmundow1y@sfgate.com", false, null, null, false, null, null, null, null, null, null, false, null, null, false, "Ronstring" },
                    { 2, "Pellentesque ultrices mattis odio. Donec vitae nisi.", 0, 3, "cd5538a7-1502-4956-bc97-08d3fcc802d2", "ktolmanm@php.net", false, null, null, false, null, null, null, null, null, null, false, null, null, false, "Voyatouch" },
                    { 1, "Mauris sit amet eros. Suspendisse accumsan tortor quis turpis. Sed ante. Vivamus tortor.", 0, 4, "e9fc9e23-ef1f-43dc-a7fa-08de2a1a2a1c", "mbeecker8@deviantart.com", false, null, null, false, null, null, null, null, null, null, false, null, null, false, "Cardify" }
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookhouses_city_id",
                table: "Bookhouses",
                column: "city_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_city_id",
                table: "Users",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookCoverages");

            migrationBuilder.DropTable(
                name: "Bookhouses");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "LibCountries");
        }
    }
}
