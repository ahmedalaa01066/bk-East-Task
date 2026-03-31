using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class CandidateVacationAndRenaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeVacationRequest",
                schema: "EmployeeVacationRequests");

            migrationBuilder.DropTable(
                name: "EmployeeVacation",
                schema: "EmployeeVacations");

            migrationBuilder.EnsureSchema(
                name: "CandidateVacations");

            migrationBuilder.EnsureSchema(
                name: "Vacations");

            migrationBuilder.EnsureSchema(
                name: "VacationRequests");

            migrationBuilder.CreateTable(
                name: "Vacation",
                schema: "Vacations",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxRequestNum = table.Column<int>(type: "int", nullable: false),
                    ConfirmationLayerNum = table.Column<int>(type: "int", nullable: false),
                    IsSpecial = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CandidateVacation",
                schema: "CandidateVacations",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VacationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Counter = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateVacation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CandidateVacation_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateVacation_Vacation_VacationId",
                        column: x => x.VacationId,
                        principalSchema: "Vacations",
                        principalTable: "Vacation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequest",
                schema: "VacationRequests",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FromDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ToDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VacationRequestType = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VacationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VacationRequest_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationRequest_Vacation_VacationId",
                        column: x => x.VacationId,
                        principalSchema: "Vacations",
                        principalTable: "Vacation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateVacation_CandidateId",
                schema: "CandidateVacations",
                table: "CandidateVacation",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateVacation_VacationId",
                schema: "CandidateVacations",
                table: "CandidateVacation",
                column: "VacationId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequest_CandidateId",
                schema: "VacationRequests",
                table: "VacationRequest",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequest_VacationId",
                schema: "VacationRequests",
                table: "VacationRequest",
                column: "VacationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateVacation",
                schema: "CandidateVacations");

            migrationBuilder.DropTable(
                name: "VacationRequest",
                schema: "VacationRequests");

            migrationBuilder.DropTable(
                name: "Vacation",
                schema: "Vacations");

            migrationBuilder.EnsureSchema(
                name: "EmployeeVacations");

            migrationBuilder.EnsureSchema(
                name: "EmployeeVacationRequests");

            migrationBuilder.CreateTable(
                name: "EmployeeVacation",
                schema: "EmployeeVacations",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConfirmationLayerNum = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    MaxRequestNum = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVacation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeVacationRequest",
                schema: "EmployeeVacationRequests",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeVacationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    FromDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ToDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VacationRequestType = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeVacationRequest_EmployeeVacation_EmployeeVacationId",
                        column: x => x.EmployeeVacationId,
                        principalSchema: "EmployeeVacations",
                        principalTable: "EmployeeVacation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
    }
}
