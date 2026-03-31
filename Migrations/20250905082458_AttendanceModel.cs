using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class AttendanceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Attendances");

            migrationBuilder.CreateTable(
                name: "Attendance",
                schema: "Attendances",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActualStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShiftId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attendance_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendance_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalSchema: "Shifts",
                        principalTable: "Shift",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_CandidateId",
                schema: "Attendances",
                table: "Attendance",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ShiftId",
                schema: "Attendances",
                table: "Attendance",
                column: "ShiftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance",
                schema: "Attendances");
        }
    }
}
