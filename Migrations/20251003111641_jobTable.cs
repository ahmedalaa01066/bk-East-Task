using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class jobTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Jobs");

            migrationBuilder.AddColumn<string>(
                name: "JobId",
                schema: "Candidates",
                table: "Candidate",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Job",
                schema: "Jobs",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagementId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Job_Management_ManagementId",
                        column: x => x.ManagementId,
                        principalSchema: "Managements",
                        principalTable: "Management",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_JobId",
                schema: "Candidates",
                table: "Candidate",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_ManagementId",
                schema: "Jobs",
                table: "Job",
                column: "ManagementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Job_JobId",
                schema: "Candidates",
                table: "Candidate",
                column: "JobId",
                principalSchema: "Jobs",
                principalTable: "Job",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Job_JobId",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropTable(
                name: "Job",
                schema: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_JobId",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "JobId",
                schema: "Candidates",
                table: "Candidate");
        }
    }
}
