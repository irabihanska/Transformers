using Microsoft.EntityFrameworkCore.Migrations;

namespace LibroSwap.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coverage_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coverages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coverages",
                columns: new[] { "Id", "coverage_name" },
                values: new object[] { 1, "Тверда" });

            migrationBuilder.InsertData(
                table: "Coverages",
                columns: new[] { "Id", "coverage_name" },
                values: new object[] { 2, "М'яка" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coverages");
        }
    }
}
