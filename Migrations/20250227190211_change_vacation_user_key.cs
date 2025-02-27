using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class change_vacation_user_key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VacationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    AssignedToId = table.Column<int>(type: "integer", nullable: false),
                    AssignedUserId = table.Column<int>(type: "integer", nullable: false),
                    VacationStatusId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vacations_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vacations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vacations_VacationStatuses_VacationStatusId",
                        column: x => x.VacationStatusId,
                        principalTable: "VacationStatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_vacations_AssignedUserId",
                table: "vacations",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_vacations_UserId",
                table: "vacations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_vacations_VacationStatusId",
                table: "vacations",
                column: "VacationStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vacations");

            migrationBuilder.DropTable(
                name: "VacationStatuses");
        }
    }
}
