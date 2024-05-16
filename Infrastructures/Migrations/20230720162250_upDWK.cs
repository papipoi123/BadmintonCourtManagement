using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class upDWK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingSlotInAMonth_SalaryCoefficient_salaryCoefficientId",
                table: "WorkingSlotInAMonth");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingSlotInAMonth_WorkingManagement_workingManagementId",
                table: "WorkingSlotInAMonth");

            migrationBuilder.AlterColumn<int>(
                name: "workingManagementId",
                table: "WorkingSlotInAMonth",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "salaryCoefficientId",
                table: "WorkingSlotInAMonth",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingSlotInAMonth_SalaryCoefficient_salaryCoefficientId",
                table: "WorkingSlotInAMonth",
                column: "salaryCoefficientId",
                principalTable: "SalaryCoefficient",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingSlotInAMonth_WorkingManagement_workingManagementId",
                table: "WorkingSlotInAMonth",
                column: "workingManagementId",
                principalTable: "WorkingManagement",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingSlotInAMonth_SalaryCoefficient_salaryCoefficientId",
                table: "WorkingSlotInAMonth");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingSlotInAMonth_WorkingManagement_workingManagementId",
                table: "WorkingSlotInAMonth");

            migrationBuilder.AlterColumn<int>(
                name: "workingManagementId",
                table: "WorkingSlotInAMonth",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "salaryCoefficientId",
                table: "WorkingSlotInAMonth",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingSlotInAMonth_SalaryCoefficient_salaryCoefficientId",
                table: "WorkingSlotInAMonth",
                column: "salaryCoefficientId",
                principalTable: "SalaryCoefficient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingSlotInAMonth_WorkingManagement_workingManagementId",
                table: "WorkingSlotInAMonth",
                column: "workingManagementId",
                principalTable: "WorkingManagement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
