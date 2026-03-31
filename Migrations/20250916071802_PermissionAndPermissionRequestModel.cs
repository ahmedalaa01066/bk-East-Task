using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class PermissionAndPermissionRequestModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Permissions");

            migrationBuilder.EnsureSchema(
                name: "PermissionRequests");

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "Permissions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxHours = table.Column<int>(type: "int", nullable: false),
                    MinHours = table.Column<int>(type: "int", nullable: false),
                    RepeatTimes = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRequest",
                schema: "PermissionRequests",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    FromTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ToTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionRequest_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRequest_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "Permissions",
                        principalTable: "Permission",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRequest_CandidateId",
                schema: "PermissionRequests",
                table: "PermissionRequest",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRequest_PermissionId",
                schema: "PermissionRequests",
                table: "PermissionRequest",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionRequest",
                schema: "PermissionRequests");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "Permissions");
        }
    }
}
