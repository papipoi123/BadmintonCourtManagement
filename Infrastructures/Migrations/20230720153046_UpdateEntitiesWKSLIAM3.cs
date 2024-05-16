using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitiesWKSLIAM3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BasicSalary",
                table: "WorkingSlotInAMonth",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "salaryCoefficient",
                table: "WorkingSlotInAMonth",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasicSalary",
                table: "WorkingSlotInAMonth");

            migrationBuilder.DropColumn(
                name: "salaryCoefficient",
                table: "WorkingSlotInAMonth");
        }
    }
}
