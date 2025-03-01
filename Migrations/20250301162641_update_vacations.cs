using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class update_vacations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacations_Users_AssignedUserId",
                table: "vacations");

            migrationBuilder.DropIndex(
                name: "IX_vacations_AssignedUserId",
                table: "vacations");

            migrationBuilder.DropColumn(
                name: "AssignedToId",
                table: "vacations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedToId",
                table: "vacations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_vacations_AssignedUserId",
                table: "vacations",
                column: "AssignedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_Users_AssignedUserId",
                table: "vacations",
                column: "AssignedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
