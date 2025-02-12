using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class seeding_task_statuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"TaskStatuses\" (\"Id\", \"Name\") VALUES (1, 'მიმდინარე'), (2, 'დასრულებული'),(3,'დაბრუნებული') ON CONFLICT (\"Id\") DO NOTHING;");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE \"TaskStatuses\" CASCADE");

        }
    }
}
