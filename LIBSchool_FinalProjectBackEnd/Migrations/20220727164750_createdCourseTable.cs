using Microsoft.EntityFrameworkCore.Migrations;

namespace LIBSchool_FinalProjectBackEnd.Migrations
{
    public partial class createdCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SubName = table.Column<string>(nullable: true),
                    İnformation = table.Column<string>(nullable: false),
                    Belong = table.Column<string>(nullable: false),
                    Condition = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationFormats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher = table.Column<string>(nullable: true),
                    Time = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Subtitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "EducationFormats");

            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
