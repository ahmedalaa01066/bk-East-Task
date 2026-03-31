using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.RenameColumn(
                name: "RepeatTimes",
                schema: "Permissions",
                table: "Permission",
                newName: "MaxRepeatTimes");

            migrationBuilder.AddColumn<int>(
                name: "MaxHoursPerMonth",
                schema: "Permissions",
                table: "Permission",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxHoursPerMonth",
                schema: "Permissions",
                table: "Permission");

            migrationBuilder.RenameColumn(
                name: "MaxRepeatTimes",
                schema: "Permissions",
                table: "Permission",
                newName: "RepeatTimes");
        }
    }
}
