using Microsoft.EntityFrameworkCore.Migrations;

namespace apiHangFire.Migrations
{
    public partial class @enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_objBook",
                table: "books");

            migrationBuilder.RenameTable(
                name: "books",
                newName: "books");

            migrationBuilder.AddColumn<int>(
                name: "types",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                table: "books",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                table: "books");

            migrationBuilder.DropColumn(
                name: "types",
                table: "books");

            migrationBuilder.RenameTable(
                name: "books",
                newName: "books");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "books",
                column: "Id");
        }
    }
}
