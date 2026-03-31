using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class ExternalCandidateAndCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ExternalCompanies");

            migrationBuilder.EnsureSchema(
                name: "ExternalMember");

            migrationBuilder.CreateTable(
                name: "ExternalCompany",
                schema: "ExternalCompanies",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalCompany", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExternalMember",
                schema: "ExternalMember",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExternalCompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalMember", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExternalMember_ExternalCompany_ExternalCompanyId",
                        column: x => x.ExternalCompanyId,
                        principalSchema: "ExternalCompanies",
                        principalTable: "ExternalCompany",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalMember_Position_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "Positions",
                        principalTable: "Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalMember_ExternalCompanyId",
                schema: "ExternalMember",
                table: "ExternalMember",
                column: "ExternalCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalMember_PositionId",
                schema: "ExternalMember",
                table: "ExternalMember",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalMember",
                schema: "ExternalMember");

            migrationBuilder.DropTable(
                name: "ExternalCompany",
                schema: "ExternalCompanies");
        }
    }
}
