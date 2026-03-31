using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionRequestStatusColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VacationRequestType",
                schema: "VacationRequests",
                table: "VacationRequest",
                newName: "VacationRequestStatus");

            migrationBuilder.RenameColumn(
                name: "PermissionRequestType",
                schema: "PermissionRequests",
                table: "PermissionRequest",
                newName: "PermissionRequestStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VacationRequestStatus",
                schema: "VacationRequests",
                table: "VacationRequest",
                newName: "VacationRequestType");

            migrationBuilder.RenameColumn(
                name: "PermissionRequestStatus",
                schema: "PermissionRequests",
                table: "PermissionRequest",
                newName: "PermissionRequestType");
        }
    }
}
