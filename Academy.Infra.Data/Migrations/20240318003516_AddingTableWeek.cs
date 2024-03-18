using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Academy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingTableWeek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanTime_Plan_PlayId",
                table: "PlanTime");

            migrationBuilder.RenameColumn(
                name: "PlayId",
                table: "PlanTime",
                newName: "WeekId");

            migrationBuilder.RenameColumn(
                name: "DayWeek",
                table: "PlanTime",
                newName: "PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanTime_PlayId",
                table: "PlanTime",
                newName: "IX_PlanTime_WeekId");

            migrationBuilder.CreateTable(
                name: "Week",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Week", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Week",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sunday" },
                    { 2, "Monday" },
                    { 3, "Tuesday" },
                    { 4, "Wednesday" },
                    { 5, "Thusday" },
                    { 6, "Friday" },
                    { 7, "Saturday" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanTime_PlanId",
                table: "PlanTime",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanTime_Plan_PlanId",
                table: "PlanTime",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanTime_Week_WeekId",
                table: "PlanTime",
                column: "WeekId",
                principalTable: "Week",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanTime_Plan_PlanId",
                table: "PlanTime");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanTime_Week_WeekId",
                table: "PlanTime");

            migrationBuilder.DropTable(
                name: "Week");

            migrationBuilder.DropIndex(
                name: "IX_PlanTime_PlanId",
                table: "PlanTime");

            migrationBuilder.RenameColumn(
                name: "WeekId",
                table: "PlanTime",
                newName: "PlayId");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "PlanTime",
                newName: "DayWeek");

            migrationBuilder.RenameIndex(
                name: "IX_PlanTime_WeekId",
                table: "PlanTime",
                newName: "IX_PlanTime_PlayId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanTime_Plan_PlayId",
                table: "PlanTime",
                column: "PlayId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
