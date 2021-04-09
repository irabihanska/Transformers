using Microsoft.EntityFrameworkCore.Migrations;

namespace LibroSwap.Migrations
{
    public partial class BookhousesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Bookhouses",
                columns: new[] { "Id", "bookhouse_name", "city_id" },
                values: new object[] { 1, "Видавництво Старого Лева", 1 });

            migrationBuilder.InsertData(
                table: "Bookhouses",
                columns: new[] { "Id", "bookhouse_name", "city_id" },
                values: new object[] { 2, "Видавництво Івана Малковича „А-ба-ба-га-ла-ма-га", 2 });

            migrationBuilder.InsertData(
                table: "Bookhouses",
                columns: new[] { "Id", "bookhouse_name", "city_id" },
                values: new object[] { 3, "Bloomsbury", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Bookhouses_city_id",
                table: "Bookhouses",
                column: "city_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookhouses");
        }
    }
}
