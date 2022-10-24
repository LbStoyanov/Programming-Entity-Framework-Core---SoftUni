using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Data.Migrations
{
    public partial class NameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Courses_CourseId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Students_StudentId",
                table: "Homeworks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Homeworks",
                table: "Homeworks");

            migrationBuilder.RenameTable(
                name: "Homeworks",
                newName: "HomeworSubmissions");

            migrationBuilder.RenameIndex(
                name: "IX_Homeworks_StudentId",
                table: "HomeworSubmissions",
                newName: "IX_HomeworSubmissions_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Homeworks_CourseId",
                table: "HomeworSubmissions",
                newName: "IX_HomeworSubmissions_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeworSubmissions",
                table: "HomeworSubmissions",
                column: "HomeworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworSubmissions_Courses_CourseId",
                table: "HomeworSubmissions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworSubmissions_Students_StudentId",
                table: "HomeworSubmissions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworSubmissions_Courses_CourseId",
                table: "HomeworSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeworSubmissions_Students_StudentId",
                table: "HomeworSubmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeworSubmissions",
                table: "HomeworSubmissions");

            migrationBuilder.RenameTable(
                name: "HomeworSubmissions",
                newName: "Homeworks");

            migrationBuilder.RenameIndex(
                name: "IX_HomeworSubmissions_StudentId",
                table: "Homeworks",
                newName: "IX_Homeworks_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeworSubmissions_CourseId",
                table: "Homeworks",
                newName: "IX_Homeworks_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Homeworks",
                table: "Homeworks",
                column: "HomeworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Courses_CourseId",
                table: "Homeworks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Students_StudentId",
                table: "Homeworks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
