using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment5Class16.Migrations
{
    public partial class BookIssueAndReturnsInStudentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Books_BookId",
                table: "BorrowBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowBooks_BookId",
                table: "BorrowBooks");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BorrowBooks");

            migrationBuilder.CreateTable(
                name: "ReturnBooks",
                columns: table => new
                {
                    Barcode = table.Column<string>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    BooksReturnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnBooks", x => x.Barcode);
                    table.ForeignKey(
                        name: "FK_ReturnBooks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReturnBooks_StudentId",
                table: "ReturnBooks",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturnBooks");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BorrowBooks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_BookId",
                table: "BorrowBooks",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Books_BookId",
                table: "BorrowBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
