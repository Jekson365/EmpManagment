using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedTasks_Users_TaskId",
                table: "AssignedTasks");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTasks_UserId",
                table: "AssignedTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedTasks_Users_UserId",
                table: "AssignedTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedTasks_Users_UserId",
                table: "AssignedTasks");

            migrationBuilder.DropIndex(
                name: "IX_AssignedTasks_UserId",
                table: "AssignedTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedTasks_Users_TaskId",
                table: "AssignedTasks",
                column: "TaskId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
