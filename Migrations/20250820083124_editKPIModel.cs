using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class editKPIModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_CandidateKPI_CandidateKPIId",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_KPI_CandidateKPI_CandidateKPIId",
                schema: "KPIs",
                table: "KPI");

            migrationBuilder.DropIndex(
                name: "IX_KPI_CandidateKPIId",
                schema: "KPIs",
                table: "KPI");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_CandidateKPIId",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "CandidateKPIId",
                schema: "KPIs",
                table: "KPI");

            migrationBuilder.DropColumn(
                name: "CandidateKPIId",
                schema: "Candidates",
                table: "Candidate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CandidateKPIId",
                schema: "KPIs",
                table: "KPI",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CandidateKPIId",
                schema: "Candidates",
                table: "Candidate",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KPI_CandidateKPIId",
                schema: "KPIs",
                table: "KPI",
                column: "CandidateKPIId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_CandidateKPIId",
                schema: "Candidates",
                table: "Candidate",
                column: "CandidateKPIId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_CandidateKPI_CandidateKPIId",
                schema: "Candidates",
                table: "Candidate",
                column: "CandidateKPIId",
                principalSchema: "CandidateKPIs",
                principalTable: "CandidateKPI",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KPI_CandidateKPI_CandidateKPIId",
                schema: "KPIs",
                table: "KPI",
                column: "CandidateKPIId",
                principalSchema: "CandidateKPIs",
                principalTable: "CandidateKPI",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
