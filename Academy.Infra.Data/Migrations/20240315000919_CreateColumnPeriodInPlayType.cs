using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateColumnPeriodInPlayType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "PlanType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PlanType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Period",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PlanType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Period",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PlanType",
                keyColumn: "Id",
                keyValue: 3,
                column: "Period",
                value: 6);

            migrationBuilder.UpdateData(
                table: "PlanType",
                keyColumn: "Id",
                keyValue: 4,
                column: "Period",
                value: 12);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "PlanType");
        }
    }
}
