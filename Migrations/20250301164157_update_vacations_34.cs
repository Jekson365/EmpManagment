using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class update_vacations_34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacations_VacationStatuses_StatusId",
                table: "vacations");

            migrationBuilder.DropIndex(
                name: "IX_vacations_StatusId",
                table: "vacations");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "vacations");

            migrationBuilder.AddColumn<int>(
                name: "VacationStatusId",
                table: "vacations",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vacations_VacationStatusId",
                table: "vacations",
                column: "VacationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_VacationStatuses_VacationStatusId",
                table: "vacations",
                column: "VacationStatusId",
                principalTable: "VacationStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacations_VacationStatuses_VacationStatusId",
                table: "vacations");

            migrationBuilder.DropIndex(
                name: "IX_vacations_VacationStatusId",
                table: "vacations");

            migrationBuilder.DropColumn(
                name: "VacationStatusId",
                table: "vacations");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "vacations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_vacations_StatusId",
                table: "vacations",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_VacationStatuses_StatusId",
                table: "vacations",
                column: "StatusId",
                principalTable: "VacationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
