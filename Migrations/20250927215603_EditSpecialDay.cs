using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class EditSpecialDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToTime",
                schema: "SpecialDays",
                table: "SpecialDay",
                newName: "ToDate");

            migrationBuilder.RenameColumn(
                name: "FromTime",
                schema: "SpecialDays",
                table: "SpecialDay",
                newName: "FromDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToDate",
                schema: "SpecialDays",
                table: "SpecialDay",
                newName: "ToTime");

            migrationBuilder.RenameColumn(
                name: "FromDate",
                schema: "SpecialDays",
                table: "SpecialDay",
                newName: "FromTime");
        }
    }
}
