using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class demo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicSalary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    basicSalary = table.Column<double>(type: "float", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicSalary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Court",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courtCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalPerson = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    availableStatus = table.Column<int>(type: "int", nullable: false),
                    reservationStatus = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Court", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    holidayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    holidayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    workingCoefficient = table.Column<double>(type: "float", nullable: false),
                    bookingCoefficient = table.Column<double>(type: "float", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryCoefficient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coefficientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coefficientForHour = table.Column<double>(type: "float", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryCoefficient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    voucherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discountPercent = table.Column<double>(type: "float", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingManagement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbsentRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    absentReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reportStatus = table.Column<int>(type: "int", nullable: false),
                    requestType = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsentRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbsentRequest_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Furlough",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalFurloughDay = table.Column<int>(type: "int", nullable: false),
                    remainFurlough = table.Column<int>(type: "int", nullable: false),
                    usedFurlough = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furlough", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Furlough_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffWorkingProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalPresent = table.Column<int>(type: "int", nullable: false),
                    totalAbsent = table.Column<int>(type: "int", nullable: false),
                    totalSalary = table.Column<double>(type: "float", nullable: false),
                    retireStatus = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffWorkingProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffWorkingProfile_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sendTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paymentId = table.Column<int>(type: "int", nullable: false),
                    voucherId = table.Column<int>(type: "int", nullable: false),
                    holidayId = table.Column<int>(type: "int", nullable: true),
                    totalPrice = table.Column<decimal>(type: "money", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Holiday_holidayId",
                        column: x => x.holidayId,
                        principalTable: "Holiday",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservation_Payment_paymentId",
                        column: x => x.paymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Vouchers_voucherId",
                        column: x => x.voucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingSlotInAMonth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    slotHour = table.Column<int>(type: "int", nullable: false),
                    slotSalary = table.Column<double>(type: "float", nullable: false),
                    workingStatus = table.Column<int>(type: "int", nullable: false),
                    workingManagementId = table.Column<int>(type: "int", nullable: false),
                    salaryCoefficientId = table.Column<int>(type: "int", nullable: false),
                    basicSalaryId = table.Column<int>(type: "int", nullable: false),
                    holidayId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingSlotInAMonth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingSlotInAMonth_BasicSalary_basicSalaryId",
                        column: x => x.basicSalaryId,
                        principalTable: "BasicSalary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingSlotInAMonth_Holiday_holidayId",
                        column: x => x.holidayId,
                        principalTable: "Holiday",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingSlotInAMonth_SalaryCoefficient_salaryCoefficientId",
                        column: x => x.salaryCoefficientId,
                        principalTable: "SalaryCoefficient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingSlotInAMonth_WorkingManagement_workingManagementId",
                        column: x => x.workingManagementId,
                        principalTable: "WorkingManagement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationDetail",
                columns: table => new
                {
                    CourtId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDetail", x => new { x.ReservationId, x.CourtId });
                    table.ForeignKey(
                        name: "FK_ReservationDetail_Court_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Court",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationDetail_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSlot",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false),
                    workingSlotInAMonthId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSlot", x => new { x.workingSlotInAMonthId, x.userId });
                    table.ForeignKey(
                        name: "FK_UserSlot_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSlot_WorkingSlotInAMonth_workingSlotInAMonthId",
                        column: x => x.workingSlotInAMonthId,
                        principalTable: "WorkingSlotInAMonth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbsentRequest_userId",
                table: "AbsentRequest",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Furlough_userId",
                table: "Furlough",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_holidayId",
                table: "Reservation",
                column: "holidayId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_paymentId",
                table: "Reservation",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_userId",
                table: "Reservation",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_voucherId",
                table: "Reservation",
                column: "voucherId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDetail_CourtId",
                table: "ReservationDetail",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffWorkingProfile_userId",
                table: "StaffWorkingProfile",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_User_email",
                table: "User",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSlot_userId",
                table: "UserSlot",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSlotInAMonth_basicSalaryId",
                table: "WorkingSlotInAMonth",
                column: "basicSalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSlotInAMonth_holidayId",
                table: "WorkingSlotInAMonth",
                column: "holidayId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSlotInAMonth_salaryCoefficientId",
                table: "WorkingSlotInAMonth",
                column: "salaryCoefficientId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSlotInAMonth_workingManagementId",
                table: "WorkingSlotInAMonth",
                column: "workingManagementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbsentRequest");

            migrationBuilder.DropTable(
                name: "Furlough");

            migrationBuilder.DropTable(
                name: "ReservationDetail");

            migrationBuilder.DropTable(
                name: "StaffWorkingProfile");

            migrationBuilder.DropTable(
                name: "UserSlot");

            migrationBuilder.DropTable(
                name: "Court");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "WorkingSlotInAMonth");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "BasicSalary");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "SalaryCoefficient");

            migrationBuilder.DropTable(
                name: "WorkingManagement");
        }
    }
}
