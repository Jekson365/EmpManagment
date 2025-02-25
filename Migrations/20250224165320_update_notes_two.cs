using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class update_notes_two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_CreateById",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "Notes",
                newName: "CreatedById`");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_CreateById",
                table: "Notes",
                newName: "IX_Notes_CreatedById`");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_CreatedById`",
                table: "Notes",
                column: "CreatedById`",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_CreatedById`",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "CreatedById`",
                table: "Notes",
                newName: "CreateById");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_CreatedById`",
                table: "Notes",
                newName: "IX_Notes_CreateById");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_CreateById",
                table: "Notes",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
