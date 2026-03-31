using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class PermissionLogModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PermissionLogs");

            migrationBuilder.CreateTable(
                name: "PermissionLog",
                schema: "PermissionLogs",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComeBackDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionLog_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionLog_CandidateId",
                schema: "PermissionLogs",
                table: "PermissionLog",
                column: "CandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionLog",
                schema: "PermissionLogs");
        }
    }
}
