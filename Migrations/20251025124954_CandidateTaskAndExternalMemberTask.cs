using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class CandidateTaskAndExternalMemberTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CandidateTasks");

            migrationBuilder.EnsureSchema(
                name: "ExternalMemberTasks");

            migrationBuilder.CreateTable(
                name: "CandidateTask",
                schema: "CandidateTasks",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectTaskId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateTask", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CandidateTask_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateTask_ProjectTask_ProjectTaskId",
                        column: x => x.ProjectTaskId,
                        principalSchema: "ProjectTask",
                        principalTable: "ProjectTask",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalMemberTask",
                schema: "ExternalMemberTasks",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExternalMemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectTaskId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalMemberTask", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExternalMemberTask_ExternalMember_ExternalMemberId",
                        column: x => x.ExternalMemberId,
                        principalSchema: "ExternalMember",
                        principalTable: "ExternalMember",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalMemberTask_ProjectTask_ProjectTaskId",
                        column: x => x.ProjectTaskId,
                        principalSchema: "ProjectTask",
                        principalTable: "ProjectTask",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTask_CandidateId",
                schema: "CandidateTasks",
                table: "CandidateTask",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTask_ProjectTaskId",
                schema: "CandidateTasks",
                table: "CandidateTask",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalMemberTask_ExternalMemberId",
                schema: "ExternalMemberTasks",
                table: "ExternalMemberTask",
                column: "ExternalMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalMemberTask_ProjectTaskId",
                schema: "ExternalMemberTasks",
                table: "ExternalMemberTask",
                column: "ProjectTaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateTask",
                schema: "CandidateTasks");

            migrationBuilder.DropTable(
                name: "ExternalMemberTask",
                schema: "ExternalMemberTasks");
        }
    }
}
