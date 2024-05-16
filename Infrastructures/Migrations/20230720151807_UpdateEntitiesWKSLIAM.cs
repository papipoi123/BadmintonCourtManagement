using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitiesWKSLIAM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingSlotInAMonth_Holiday_holidayId",
                table: "WorkingSlotInAMonth");

            migrationBuilder.AlterColumn<int>(
                name: "holidayId",
                table: "WorkingSlotInAMonth",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingSlotInAMonth_Holiday_holidayId",
                table: "WorkingSlotInAMonth",
                column: "holidayId",
                principalTable: "Holiday",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingSlotInAMonth_Holiday_holidayId",
                table: "WorkingSlotInAMonth");

            migrationBuilder.AlterColumn<int>(
                name: "holidayId",
                table: "WorkingSlotInAMonth",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingSlotInAMonth_Holiday_holidayId",
                table: "WorkingSlotInAMonth",
                column: "holidayId",
                principalTable: "Holiday",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
