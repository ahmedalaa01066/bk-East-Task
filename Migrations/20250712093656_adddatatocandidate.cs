using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class adddatatocandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                schema: "Candidates",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobCode",
                schema: "Candidates",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "JobCode",
                schema: "Candidates",
                table: "Candidate");
        }
    }
}
