using Microsoft.EntityFrameworkCore.Migrations;

namespace NarojayBlog.DatabaseRepository.Migrations
{
    public partial class _20190828 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Guestbooks",
                table: "Guestbooks");

            migrationBuilder.RenameTable(
                name: "Guestbooks",
                newName: "GuestBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestBooks",
                table: "GuestBooks",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestBooks",
                table: "GuestBooks");

            migrationBuilder.RenameTable(
                name: "GuestBooks",
                newName: "Guestbooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guestbooks",
                table: "Guestbooks",
                column: "Id");
        }
    }
}
