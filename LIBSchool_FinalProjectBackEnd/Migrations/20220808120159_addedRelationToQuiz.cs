using Microsoft.EntityFrameworkCore.Migrations;

namespace LIBSchool_FinalProjectBackEnd.Migrations
{
    public partial class addedRelationToQuiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuizTeacherId",
                table: "QuizInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuizTimeId",
                table: "QuizInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuizInfos_QuizTeacherId",
                table: "QuizInfos",
                column: "QuizTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizInfos_QuizTimeId",
                table: "QuizInfos",
                column: "QuizTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizInfos_QuizTeachers_QuizTeacherId",
                table: "QuizInfos",
                column: "QuizTeacherId",
                principalTable: "QuizTeachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizInfos_QuizTimes_QuizTimeId",
                table: "QuizInfos",
                column: "QuizTimeId",
                principalTable: "QuizTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizInfos_QuizTeachers_QuizTeacherId",
                table: "QuizInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizInfos_QuizTimes_QuizTimeId",
                table: "QuizInfos");

            migrationBuilder.DropIndex(
                name: "IX_QuizInfos_QuizTeacherId",
                table: "QuizInfos");

            migrationBuilder.DropIndex(
                name: "IX_QuizInfos_QuizTimeId",
                table: "QuizInfos");

            migrationBuilder.DropColumn(
                name: "QuizTeacherId",
                table: "QuizInfos");

            migrationBuilder.DropColumn(
                name: "QuizTimeId",
                table: "QuizInfos");
        }
    }
}
