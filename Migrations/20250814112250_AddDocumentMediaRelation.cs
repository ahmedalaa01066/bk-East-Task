using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTask.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentMediaRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                schema: "Medias",
                table: "Media",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_DocumentId",
                schema: "Medias",
                table: "Media",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Document_DocumentId",
                schema: "Medias",
                table: "Media",
                column: "DocumentId",
                principalSchema: "Documents",
                principalTable: "Document",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Document_DocumentId",
                schema: "Medias",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_DocumentId",
                schema: "Medias",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                schema: "Medias",
                table: "Media");
        }
    }
}
