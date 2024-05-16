using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class fixWKSLAllownull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingSlotInAMonth_BasicSalary_basicSalaryId",
                table: "WorkingSlotInAMonth");

            migrationBuilder.DropIndex(
                name: "IX_WorkingSlotInAMonth_basicSalaryId",
                table: "WorkingSlotInAMonth");

            migrationBuilder.DropColumn(
                name: "basicSalaryId",
                table: "WorkingSlotInAMonth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "basicSalaryId",
                table: "WorkingSlotInAMonth",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSlotInAMonth_basicSalaryId",
                table: "WorkingSlotInAMonth",
                column: "basicSalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingSlotInAMonth_BasicSalary_basicSalaryId",
                table: "WorkingSlotInAMonth",
                column: "basicSalaryId",
                principalTable: "BasicSalary",
                principalColumn: "Id");
        }
    }
}
