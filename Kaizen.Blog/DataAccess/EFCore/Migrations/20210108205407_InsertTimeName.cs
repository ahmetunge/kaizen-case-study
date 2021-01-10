using Microsoft.EntityFrameworkCore.Migrations;

namespace Kaizen.Blog.DataAccess.EFCore.Migrations
{
    public partial class InsertTimeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InserTime",
                table: "Users",
                newName: "InsertTime");

            migrationBuilder.RenameColumn(
                name: "InserTime",
                table: "Categories",
                newName: "InsertTime");

            migrationBuilder.RenameColumn(
                name: "InserTime",
                table: "Articles",
                newName: "InsertTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsertTime",
                table: "Users",
                newName: "InserTime");

            migrationBuilder.RenameColumn(
                name: "InsertTime",
                table: "Categories",
                newName: "InserTime");

            migrationBuilder.RenameColumn(
                name: "InsertTime",
                table: "Articles",
                newName: "InserTime");
        }
    }
}
