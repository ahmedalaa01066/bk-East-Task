using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class AddCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Candidates");

            migrationBuilder.CreateTable(
                name: "Candidate",
                schema: "Candidates",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoiningDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateStatus = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ManagementId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LevelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PositionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Candidate_Candidate_ManagerId",
                        column: x => x.ManagerId,
                        principalSchema: "Candidates",
                        principalTable: "Candidate",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Candidate_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Departments",
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Candidate_Level_LevelId",
                        column: x => x.LevelId,
                        principalSchema: "Levels",
                        principalTable: "Level",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Candidate_Management_ManagementId",
                        column: x => x.ManagementId,
                        principalSchema: "Managements",
                        principalTable: "Management",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Candidate_Position_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "Positions",
                        principalTable: "Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Candidate_User_ID",
                        column: x => x.ID,
                        principalSchema: "Users",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_DepartmentId",
                schema: "Candidates",
                table: "Candidate",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_LevelId",
                schema: "Candidates",
                table: "Candidate",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_ManagementId",
                schema: "Candidates",
                table: "Candidate",
                column: "ManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_ManagerId",
                schema: "Candidates",
                table: "Candidate",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_PositionId",
                schema: "Candidates",
                table: "Candidate",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidate",
                schema: "Candidates");
        }
    }
}
