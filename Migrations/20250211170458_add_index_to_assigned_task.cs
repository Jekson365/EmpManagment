using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class add_index_to_assigned_task : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssignedTasks_TaskId",
                table: "AssignedTasks");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTasks_TaskId_UserId",
                table: "AssignedTasks",
                columns: new[] { "TaskId", "UserId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssignedTasks_TaskId_UserId",
                table: "AssignedTasks");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTasks_TaskId",
                table: "AssignedTasks",
                column: "TaskId");
        }
    }
}
