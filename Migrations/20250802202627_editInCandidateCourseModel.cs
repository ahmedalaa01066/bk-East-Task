using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class editInCandidateCourseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDate",
                schema: "CandidateCourses",
                table: "CandidateCourse",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                schema: "CandidateCourses",
                table: "CandidateCourse",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "CandidateCourses",
                table: "CandidateCourse");

            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "CandidateCourses",
                table: "CandidateCourse");
        }
    }
}
