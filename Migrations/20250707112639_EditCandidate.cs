using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class EditCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_User_ID",
                schema: "Candidates",
                table: "Candidate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_User_ID",
                schema: "Candidates",
                table: "Candidate",
                column: "ID",
                principalSchema: "Users",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
