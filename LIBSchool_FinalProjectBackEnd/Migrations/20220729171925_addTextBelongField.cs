using Microsoft.EntityFrameworkCore.Migrations;

namespace LIBSchool_FinalProjectBackEnd.Migrations
{
    public partial class addTextBelongField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Belong",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "BelongText",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BelongTitle",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BelongText",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "BelongTitle",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Belong",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
