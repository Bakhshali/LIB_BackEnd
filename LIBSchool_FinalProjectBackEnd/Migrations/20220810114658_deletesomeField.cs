using Microsoft.EntityFrameworkCore.Migrations;

namespace LIBSchool_FinalProjectBackEnd.Migrations
{
    public partial class deletesomeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupPrice",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "İndividualPrice",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GroupPrice",
                table: "Courses",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "İndividualPrice",
                table: "Courses",
                type: "decimal(5,2)",
                nullable: true);
        }
    }
}
