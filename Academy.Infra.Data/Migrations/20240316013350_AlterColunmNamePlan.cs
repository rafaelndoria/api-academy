using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterColunmNamePlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_PlanType_PlayTypeId",
                table: "Plan");

            migrationBuilder.RenameColumn(
                name: "PlayTypeId",
                table: "Plan",
                newName: "PlanTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Plan_PlayTypeId",
                table: "Plan",
                newName: "IX_Plan_PlanTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_PlanType_PlanTypeId",
                table: "Plan",
                column: "PlanTypeId",
                principalTable: "PlanType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_PlanType_PlanTypeId",
                table: "Plan");

            migrationBuilder.RenameColumn(
                name: "PlanTypeId",
                table: "Plan",
                newName: "PlayTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Plan_PlanTypeId",
                table: "Plan",
                newName: "IX_Plan_PlayTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_PlanType_PlayTypeId",
                table: "Plan",
                column: "PlayTypeId",
                principalTable: "PlanType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
