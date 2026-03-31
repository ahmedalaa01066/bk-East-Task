using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAttendanceActivation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendanceActivation",
                schema: "Candidates",
                table: "Candidate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttendanceActivation",
                schema: "Candidates",
                table: "Candidate",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
