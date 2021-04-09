using Microsoft.EntityFrameworkCore.Migrations;

namespace LibroSwap.Migrations
{
    public partial class AddedHandbooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    country_code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
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
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "country_code", "country_name" },
                values: new object[,]
                {
                    { 1, "UA", "Україна" },
                    { 2, "EN", "Англія" },
                    { 3, "SCOT", "Шотландія" },
                    { 4, "FR", "Франція" }
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
                    { 1, "UKR", "Українська" },
                    { 2, "ENG", "Англійська" },
                    { 3, "FRA", "Французька" },
                    { 4, "CHI", "Китайська" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
