using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class fixSalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salaryCoefficient",
                table: "WorkingSlotInAMonth",
                newName: "salaryCoefficientBase");

            migrationBuilder.RenameColumn(
                name: "BasicSalary",
                table: "WorkingSlotInAMonth",
                newName: "basicSalaryBase");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salaryCoefficientBase",
                table: "WorkingSlotInAMonth",
                newName: "salaryCoefficient");

            migrationBuilder.RenameColumn(
                name: "basicSalaryBase",
                table: "WorkingSlotInAMonth",
                newName: "BasicSalary");
        }
    }
}
