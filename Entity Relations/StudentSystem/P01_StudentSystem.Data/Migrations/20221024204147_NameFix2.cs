using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Data.Migrations
{
    public partial class NameFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "HomeworkSubmissions");

            migrationBuilder.RenameIndex(
                name: "IX_HomeworSubmissions_StudentId",
                table: "HomeworkSubmissions",
                newName: "IX_HomeworkSubmissions_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeworSubmissions_CourseId",
                table: "HomeworkSubmissions",
                newName: "IX_HomeworkSubmissions_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeworkSubmissions",
                table: "HomeworkSubmissions",
                column: "HomeworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkSubmissions_Courses_CourseId",
                table: "HomeworkSubmissions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkSubmissions_Students_StudentId",
                table: "HomeworkSubmissions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkSubmissions_Courses_CourseId",
                table: "HomeworkSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkSubmissions_Students_StudentId",
                table: "HomeworkSubmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeworkSubmissions",
                table: "HomeworkSubmissions");

            migrationBuilder.RenameTable(
                name: "HomeworkSubmissions",
                newName: "HomeworSubmissions");

            migrationBuilder.RenameIndex(
                name: "IX_HomeworkSubmissions_StudentId",
                table: "HomeworSubmissions",
                newName: "IX_HomeworSubmissions_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeworkSubmissions_CourseId",
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
    }
}
