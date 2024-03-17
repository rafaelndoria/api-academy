using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingColumnActiveForTablePlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Plan",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Plan");
        }
    }
}
