using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class seeding_roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Roles\" (\"Id\", \"Name\") VALUES (1, 'user'), (2, 'admin'),(3,'superadmin') ON CONFLICT (\"Id\") DO NOTHING;");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE \"Roles\" CASCADE");
        }
    }
}
