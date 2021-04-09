using Microsoft.EntityFrameworkCore.Migrations;

namespace LibroSwap.Migrations
{
    public partial class UserFixedCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    surname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    about_me = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    recommendation = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    city_id = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "about_me", "city_id", "email", "name", "phone", "recommendation", "surname", "username" },
                values: new object[,]
                {
                    { 1, "Mauris sit amet eros. Suspendisse accumsan tortor quis turpis. Sed ante. Vivamus tortor.", 4, "mbeecker8@deviantart.com", null, null, null, null, "Cardify" },
                    { 2, "Pellentesque ultrices mattis odio. Donec vitae nisi.", 3, "ktolmanm@php.net", null, null, null, null, "Voyatouch" },
                    { 3, "Nullam molestie nibh in lectus. Pellentesque at nulla. Suspendisse potenti.", null, "tcothey1t@gmpg.org", null, null, null, null, "Konklab" },
                    { 4, "Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi. Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit.", 2, "jmundow1y@sfgate.com", null, null, null, null, "Ronstring" },
                    { 5, "In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.", 1, "tshimman1a@wp.com", null, null, null, null, "Flowdesk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_city_id",
                table: "Users",
                column: "city_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
