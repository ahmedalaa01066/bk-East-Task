using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class editCourseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseClassification",
                schema: "Courses",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseType",
                schema: "Courses",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasExam",
                schema: "Courses",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                schema: "Courses",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InstructorName",
                schema: "Courses",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "Courses",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseClassification",
                schema: "Courses",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseType",
                schema: "Courses",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "HasExam",
                schema: "Courses",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Hours",
                schema: "Courses",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "InstructorName",
                schema: "Courses",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Courses",
                table: "Course");
        }
    }
}
