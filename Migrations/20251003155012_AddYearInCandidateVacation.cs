using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class AddYearInCandidateVacation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                schema: "CandidateVacations",
                table: "CandidateVacation",
                type: "int",
                nullable: false,
                defaultValue: 2025);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                schema: "CandidateVacations",
                table: "CandidateVacation");
        }
    }
}
