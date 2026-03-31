using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class EditDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentDocumentId",
                schema: "Documents",
                table: "Document",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Level_Sequence",
                schema: "Levels",
                table: "Level",
                column: "Sequence",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Document_ParentDocumentId",
                schema: "Documents",
                table: "Document",
                column: "ParentDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Document_ParentDocumentId",
                schema: "Documents",
                table: "Document",
                column: "ParentDocumentId",
                principalSchema: "Documents",
                principalTable: "Document",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Document_ParentDocumentId",
                schema: "Documents",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Level_Sequence",
                schema: "Levels",
                table: "Level");

            migrationBuilder.DropIndex(
                name: "IX_Document_ParentDocumentId",
                schema: "Documents",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "ParentDocumentId",
                schema: "Documents",
                table: "Document");
        }
    }
}
