using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class migrationcourtupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "totalPerson",
                table: "Court",
                newName: "TotalPerson");

            migrationBuilder.RenameColumn(
                name: "reservationStatus",
                table: "Court",
                newName: "ReservationStatus");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Court",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Court",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "courtCode",
                table: "Court",
                newName: "CourtCode");

            migrationBuilder.RenameColumn(
                name: "availableStatus",
                table: "Court",
                newName: "AvailableStatus");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Court",
                newName: "ImageURI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPerson",
                table: "Court",
                newName: "totalPerson");

            migrationBuilder.RenameColumn(
                name: "ReservationStatus",
                table: "Court",
                newName: "reservationStatus");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Court",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Court",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CourtCode",
                table: "Court",
                newName: "courtCode");

            migrationBuilder.RenameColumn(
                name: "AvailableStatus",
                table: "Court",
                newName: "availableStatus");

            migrationBuilder.RenameColumn(
                name: "ImageURI",
                table: "Court",
                newName: "image");
        }
    }
}
