using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class AddPauseShift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PauseShifts");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalPauseDuration",
                schema: "Attendances",
                table: "Attendance",
                type: "time",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PauseShift",
                schema: "PauseShifts",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FromTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ToTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AttendanceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PauseShift", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PauseShift_Attendance_AttendanceId",
                        column: x => x.AttendanceId,
                        principalSchema: "Attendances",
                        principalTable: "Attendance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PauseShift_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PauseShift_AttendanceId",
                schema: "PauseShifts",
                table: "PauseShift",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PauseShift_CandidateId",
                schema: "PauseShifts",
                table: "PauseShift",
                column: "CandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PauseShift",
                schema: "PauseShifts");

            migrationBuilder.DropColumn(
                name: "TotalPauseDuration",
                schema: "Attendances",
                table: "Attendance");
        }
    }
}
