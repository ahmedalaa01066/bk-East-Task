using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class projectandprojecttype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Projects");

            migrationBuilder.EnsureSchema(
                name: "ProjectTypes");

            migrationBuilder.AddColumn<string>(
                name: "ProjectID",
                schema: "Candidates",
                table: "Candidate",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectType",
                schema: "ProjectTypes",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "Projects",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strategic = table.Column<bool>(type: "bit", nullable: false),
                    Financial = table.Column<bool>(type: "bit", nullable: false),
                    KickOffDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsKickOffmeeting = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deliverables = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighLevelRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectManagerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectOwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ManagementId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Project_Candidate_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Project_Candidate_ProjectOwnerId",
                        column: x => x.ProjectOwnerId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Project_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Departments",
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Project_Management_ManagementId",
                        column: x => x.ManagementId,
                        principalSchema: "Managements",
                        principalTable: "Management",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Project_ProjectType_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalSchema: "ProjectTypes",
                        principalTable: "ProjectType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_ProjectID",
                schema: "Candidates",
                table: "Candidate",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_DepartmentId",
                schema: "Projects",
                table: "Project",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ManagementId",
                schema: "Projects",
                table: "Project",
                column: "ManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectManagerId",
                schema: "Projects",
                table: "Project",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectOwnerId",
                schema: "Projects",
                table: "Project",
                column: "ProjectOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectTypeId",
                schema: "Projects",
                table: "Project",
                column: "ProjectTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Project_ProjectID",
                schema: "Candidates",
                table: "Candidate",
                column: "ProjectID",
                principalSchema: "Projects",
                principalTable: "Project",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Project_ProjectID",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectType",
                schema: "ProjectTypes");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_ProjectID",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                schema: "Candidates",
                table: "Candidate");
        }
    }
}
