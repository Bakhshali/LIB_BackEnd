using Microsoft.EntityFrameworkCore.Migrations;

namespace LIBSchool_FinalProjectBackEnd.Migrations
{
    public partial class addedURLfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Settings");
        }
    }
}
