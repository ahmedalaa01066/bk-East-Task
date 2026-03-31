using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class EditCandidateRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_User_ID",
                schema: "Candidates",
                table: "Candidate");
        }
    }
}
