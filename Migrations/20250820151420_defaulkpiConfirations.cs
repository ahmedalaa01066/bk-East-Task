using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class defaulkpiConfirations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                schema: "KPIs",
                table: "KPI");

            migrationBuilder.EnsureSchema(
                name: "DefaultKPIs");

            migrationBuilder.CreateTable(
                name: "DefaultKPI",
                schema: "DefaultKPIs",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultKPI", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultKPI",
                schema: "DefaultKPIs");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                schema: "KPIs",
                table: "KPI",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
