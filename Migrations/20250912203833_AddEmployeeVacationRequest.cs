using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeVacationRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EmployeeVacationRequests");

            migrationBuilder.CreateTable(
                name: "EmployeeVacationRequest",
                schema: "EmployeeVacationRequests",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FromDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ToDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VacationRequestType = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeVacationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVacationRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeVacationRequest_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeVacationRequest_EmployeeVacation_EmployeeVacationId",
                        column: x => x.EmployeeVacationId,
                        principalSchema: "EmployeeVacations",
                        principalTable: "EmployeeVacation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVacationRequest_CandidateId",
                schema: "EmployeeVacationRequests",
                table: "EmployeeVacationRequest",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVacationRequest_EmployeeVacationId",
                schema: "EmployeeVacationRequests",
                table: "EmployeeVacationRequest",
                column: "EmployeeVacationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeVacationRequest",
                schema: "EmployeeVacationRequests");
        }
    }
}
