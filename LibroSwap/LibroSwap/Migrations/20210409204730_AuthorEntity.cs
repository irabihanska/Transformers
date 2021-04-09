using Microsoft.EntityFrameworkCore.Migrations;

namespace LibroSwap.Migrations
{
    public partial class AuthorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    author_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    author_surname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "author_name", "author_surname" },
                values: new object[,]
                {
                    { 1, "Софія", "Андрухович" },
                    { 2, "Оксана", "Забужко" },
                    { 3, "Луїза", "Хей" },
                    { 4, "Вадим", "Зеланд" },
                    { 5, "Джоан", "Роулінг" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
