using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class update_vacations_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacations_Users_UserId",
                table: "vacations");

            migrationBuilder.DropForeignKey(
                name: "FK_vacations_VacationStatuses_VacationStatusId",
                table: "vacations");

            migrationBuilder.DropIndex(
                name: "IX_vacations_UserId",
                table: "vacations");

            migrationBuilder.DropIndex(
                name: "IX_vacations_VacationStatusId",
                table: "vacations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "vacations");

            migrationBuilder.DropColumn(
                name: "VacationStatusId",
                table: "vacations");

            migrationBuilder.CreateIndex(
                name: "IX_vacations_AssignedUserId",
                table: "vacations",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_vacations_CreatedById",
                table: "vacations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_vacations_StatusId",
                table: "vacations",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_Users_AssignedUserId",
                table: "vacations",
                column: "AssignedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_Users_CreatedById",
                table: "vacations",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_VacationStatuses_StatusId",
                table: "vacations",
                column: "StatusId",
                principalTable: "VacationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacations_Users_AssignedUserId",
                table: "vacations");

            migrationBuilder.DropForeignKey(
                name: "FK_vacations_Users_CreatedById",
                table: "vacations");

            migrationBuilder.DropForeignKey(
                name: "FK_vacations_VacationStatuses_StatusId",
                table: "vacations");

            migrationBuilder.DropIndex(
                name: "IX_vacations_AssignedUserId",
                table: "vacations");

            migrationBuilder.DropIndex(
                name: "IX_vacations_CreatedById",
                table: "vacations");

            migrationBuilder.DropIndex(
                name: "IX_vacations_StatusId",
                table: "vacations");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "vacations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VacationStatusId",
                table: "vacations",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vacations_UserId",
                table: "vacations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_vacations_VacationStatusId",
                table: "vacations",
                column: "VacationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_Users_UserId",
                table: "vacations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_VacationStatuses_VacationStatusId",
                table: "vacations",
                column: "VacationStatusId",
                principalTable: "VacationStatuses",
                principalColumn: "Id");
        }
    }
}
