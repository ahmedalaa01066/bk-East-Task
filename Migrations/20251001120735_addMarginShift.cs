using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class addMarginShift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "MarginAfter",
                schema: "Shifts",
                table: "Shift",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MarginBefore",
                schema: "Shifts",
                table: "Shift",
                type: "time",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarginAfter",
                schema: "Shifts",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "MarginBefore",
                schema: "Shifts",
                table: "Shift");
        }
    }
}
