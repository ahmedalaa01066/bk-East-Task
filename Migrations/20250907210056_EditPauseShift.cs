using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class EditPauseShift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PauseShift_Candidate_CandidateId",
                schema: "PauseShifts",
                table: "PauseShift");

            migrationBuilder.DropIndex(
                name: "IX_PauseShift_CandidateId",
                schema: "PauseShifts",
                table: "PauseShift");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                schema: "PauseShifts",
                table: "PauseShift");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CandidateId",
                schema: "PauseShifts",
                table: "PauseShift",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PauseShift_CandidateId",
                schema: "PauseShifts",
                table: "PauseShift",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_PauseShift_Candidate_CandidateId",
                schema: "PauseShifts",
                table: "PauseShift",
                column: "CandidateId",
                principalSchema: "Candidates",
                principalTable: "Candidate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
