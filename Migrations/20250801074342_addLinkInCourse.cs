using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class addLinkInCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                schema: "Courses",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                schema: "Courses",
                table: "Course");
        }
    }
}
