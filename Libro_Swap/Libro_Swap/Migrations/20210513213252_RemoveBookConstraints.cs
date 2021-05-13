using Microsoft.EntityFrameworkCore.Migrations;

namespace Libro_Swap.Migrations
{
    public partial class RemoveBookConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookAuthors_author_id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Bookhouses_bookhouse_id",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "bookhouse_id",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "author_id",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6458200a-2fad-4ac0-93d1-c6661a1959e0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b760f205-46d2-415c-9758-1b53060103ef");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "22be9aba-8b54-421d-bbcd-a4e1ccea775a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "b1900f42-c7b5-46dd-929a-e90c049e9dab");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "40e648b6-c0bc-4881-b0fc-a5693c958393");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookAuthors_author_id",
                table: "Books",
                column: "author_id",
                principalTable: "BookAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Bookhouses_bookhouse_id",
                table: "Books",
                column: "bookhouse_id",
                principalTable: "Bookhouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookAuthors_author_id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Bookhouses_bookhouse_id",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "bookhouse_id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "author_id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e9fc9e23-ef1f-43dc-a7fa-08de2a1a2a1c");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "cd5538a7-1502-4956-bc97-08d3fcc802d2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "02390099-996a-4757-a5ed-fc938f349d1a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "d5fac973-e7d3-4fe3-a6c6-e3f1cd98c3c3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "7b0ad8f9-7640-4b30-bdc2-a7f96a73c033");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookAuthors_author_id",
                table: "Books",
                column: "author_id",
                principalTable: "BookAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Bookhouses_bookhouse_id",
                table: "Books",
                column: "bookhouse_id",
                principalTable: "Bookhouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
