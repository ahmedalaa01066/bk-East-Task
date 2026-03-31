using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkPackageAndWorkPackageDependency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "WorkPackages");

            migrationBuilder.EnsureSchema(
                name: "WorkPackageDependencies");

            migrationBuilder.CreateTable(
                name: "WorkPackage",
                schema: "WorkPackages",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPackage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkPackage_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Projects",
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WorkPackageDependency",
                schema: "WorkPackageDependencies",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DependencyType = table.Column<int>(type: "int", nullable: false),
                    SourceWorkPackageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DestinationWorkPackageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPackageDependency", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkPackageDependency_WorkPackage_DestinationWorkPackageId",
                        column: x => x.DestinationWorkPackageId,
                        principalSchema: "WorkPackages",
                        principalTable: "WorkPackage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkPackageDependency_WorkPackage_SourceWorkPackageId",
                        column: x => x.SourceWorkPackageId,
                        principalSchema: "WorkPackages",
                        principalTable: "WorkPackage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkPackage_ProjectId",
                schema: "WorkPackages",
                table: "WorkPackage",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPackageDependency_DestinationWorkPackageId",
                schema: "WorkPackageDependencies",
                table: "WorkPackageDependency",
                column: "DestinationWorkPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPackageDependency_SourceWorkPackageId",
                schema: "WorkPackageDependencies",
                table: "WorkPackageDependency",
                column: "SourceWorkPackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkPackageDependency",
                schema: "WorkPackageDependencies");

            migrationBuilder.DropTable(
                name: "WorkPackage",
                schema: "WorkPackages");
        }
    }
}
