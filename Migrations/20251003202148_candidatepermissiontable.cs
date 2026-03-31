using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class candidatepermissiontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CandidatePermissions");

            migrationBuilder.CreateTable(
                name: "CandidatePermission",
                schema: "CandidatePermissions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumOfHoursOfPermission = table.Column<TimeSpan>(type: "time", nullable: false),
                    PermissionMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoursLeftInMonth = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatePermission", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CandidatePermission_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "Permissions",
                        principalTable: "Permission",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePermission_CandidateId",
                schema: "CandidatePermissions",
                table: "CandidatePermission",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePermission_PermissionId",
                schema: "CandidatePermissions",
                table: "CandidatePermission",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatePermission",
                schema: "CandidatePermissions");
        }
    }
}
