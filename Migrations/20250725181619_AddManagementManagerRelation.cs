using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class AddManagementManagerRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Department_DepartmentId",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Management_ManagementId",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                schema: "Managements",
                table: "Management",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManagementId",
                schema: "Candidates",
                table: "Candidate",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentId",
                schema: "Candidates",
                table: "Candidate",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Management_ManagerId",
                schema: "Managements",
                table: "Management",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Department_DepartmentId",
                schema: "Candidates",
                table: "Candidate",
                column: "DepartmentId",
                principalSchema: "Departments",
                principalTable: "Department",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Management_ManagementId",
                schema: "Candidates",
                table: "Candidate",
                column: "ManagementId",
                principalSchema: "Managements",
                principalTable: "Management",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Management_Candidate_ManagerId",
                schema: "Managements",
                table: "Management",
                column: "ManagerId",
                principalSchema: "Candidates",
                principalTable: "Candidate",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Department_DepartmentId",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Management_ManagementId",
                schema: "Candidates",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Management_Candidate_ManagerId",
                schema: "Managements",
                table: "Management");

            migrationBuilder.DropIndex(
                name: "IX_Management_ManagerId",
                schema: "Managements",
                table: "Management");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                schema: "Managements",
                table: "Management");

            migrationBuilder.AlterColumn<string>(
                name: "ManagementId",
                schema: "Candidates",
                table: "Candidate",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentId",
                schema: "Candidates",
                table: "Candidate",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Department_DepartmentId",
                schema: "Candidates",
                table: "Candidate",
                column: "DepartmentId",
                principalSchema: "Departments",
                principalTable: "Department",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Management_ManagementId",
                schema: "Candidates",
                table: "Candidate",
                column: "ManagementId",
                principalSchema: "Managements",
                principalTable: "Management",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
