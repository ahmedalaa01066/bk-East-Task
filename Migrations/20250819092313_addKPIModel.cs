using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class addKPIModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CandidateKPIs");

            migrationBuilder.EnsureSchema(
                name: "KPIs");

            migrationBuilder.AddColumn<string>(
                name: "CandidateKPIId",
                schema: "Candidates",
                table: "Candidate",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CandidateKPI",
                schema: "CandidateKPIs",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KPIId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateKPI", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CandidateKPI_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KPI",
                schema: "KPIs",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CandidateKPIId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPI", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KPI_CandidateKPI_CandidateKPIId",
                        column: x => x.CandidateKPIId,
                        principalSchema: "CandidateKPIs",
                        principalTable: "CandidateKPI",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_CandidateKPIId",
                schema: "Candidates",
                table: "Candidate",
                column: "CandidateKPIId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateKPI_CandidateId_KPIId",
                schema: "CandidateKPIs",
                table: "CandidateKPI",
                columns: new[] { "CandidateId", "KPIId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateKPI_KPIId",
                schema: "CandidateKPIs",
                table: "CandidateKPI",
                column: "KPIId");

            migrationBuilder.CreateIndex(
                name: "IX_KPI_CandidateKPIId",
                schema: "KPIs",
                table: "KPI",
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
                name: "FK_CandidateKPI_KPI_KPIId",
                schema: "CandidateKPIs",
                table: "CandidateKPI",
                column: "KPIId",
                principalSchema: "KPIs",
                principalTable: "KPI",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_CandidateKPI_CandidateKPIId",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateKPI_KPI_KPIId",
                schema: "CandidateKPIs",
                table: "CandidateKPI");

            migrationBuilder.DropTable(
                name: "KPI",
                schema: "KPIs");

            migrationBuilder.DropTable(
                name: "CandidateKPI",
                schema: "CandidateKPIs");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_CandidateKPIId",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "CandidateKPIId",
                schema: "Candidates",
                table: "Candidate");
        }
    }
}
