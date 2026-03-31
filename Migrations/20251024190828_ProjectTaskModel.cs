using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class ProjectTaskModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ProjectTask");

            migrationBuilder.EnsureSchema(
                name: "TaskDependencies");

            migrationBuilder.CreateTable(
                name: "ProjectTask",
                schema: "ProjectTask",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPackageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTask", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectTask_WorkPackage_WorkPackageId",
                        column: x => x.WorkPackageId,
                        principalSchema: "WorkPackages",
                        principalTable: "WorkPackage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TaskDependency",
                schema: "TaskDependencies",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DependencyType = table.Column<int>(type: "int", nullable: false),
                    SourceTaskId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DestinationTaskId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDependency", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TaskDependency_ProjectTask_DestinationTaskId",
                        column: x => x.DestinationTaskId,
                        principalSchema: "ProjectTask",
                        principalTable: "ProjectTask",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TaskDependency_ProjectTask_SourceTaskId",
                        column: x => x.SourceTaskId,
                        principalSchema: "ProjectTask",
                        principalTable: "ProjectTask",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_WorkPackageId",
                schema: "ProjectTask",
                table: "ProjectTask",
                column: "WorkPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDependency_DestinationTaskId",
                schema: "TaskDependencies",
                table: "TaskDependency",
                column: "DestinationTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDependency_SourceTaskId",
                schema: "TaskDependencies",
                table: "TaskDependency",
                column: "SourceTaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDependency",
                schema: "TaskDependencies");

            migrationBuilder.DropTable(
                name: "ProjectTask",
                schema: "ProjectTask");
        }
    }
}
