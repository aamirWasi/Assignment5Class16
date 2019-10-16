using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment5Class16.Migrations
{
    public partial class AddBarcodeToBorrowBooksModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Books_BookId",
                table: "BorrowBooks");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BorrowBooks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "BorrowBooks",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Books_BookId",
                table: "BorrowBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Books_BookId",
                table: "BorrowBooks");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "BorrowBooks");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BorrowBooks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Books_BookId",
                table: "BorrowBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
