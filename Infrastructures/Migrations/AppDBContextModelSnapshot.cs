﻿// <auto-generated />
using System;
using Infrastructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructures.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.AbsentRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("absentReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("reportStatus")
                        .HasColumnType("int");

                    b.Property<int>("requestType")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("AbsentRequest");
                });

            modelBuilder.Entity("Domain.Entities.BasicSalary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("basicSalary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("BasicSalary");
                });

            modelBuilder.Entity("Domain.Entities.Court", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailableStatus")
                        .HasColumnType("int");

                    b.Property<string>("CourtCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ReservationStatus")
                        .HasColumnType("int");

                    b.Property<int?>("TotalPerson")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Court");
                });

            modelBuilder.Entity("Domain.Entities.Furlough", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("remainFurlough")
                        .HasColumnType("int");

                    b.Property<int>("totalFurloughDay")
                        .HasColumnType("int");

                    b.Property<int>("usedFurlough")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Furlough");
                });

            modelBuilder.Entity("Domain.Entities.Holidays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("bookingCoefficient")
                        .HasColumnType("float");

                    b.Property<DateTime>("holidayDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("holidayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("workingCoefficient")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Holiday");
                });

            modelBuilder.Entity("Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("paymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("holidayId")
                        .HasColumnType("int");

                    b.Property<int?>("paymentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("sendTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("totalPrice")
                        .HasColumnType("money");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int?>("voucherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("holidayId");

                    b.HasIndex("paymentId");

                    b.HasIndex("userId");

                    b.HasIndex("voucherId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("Domain.Entities.SalaryCoefficient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("coefficientForHour")
                        .HasColumnType("float");

                    b.Property<string>("coefficientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SalaryCoefficient");
                });

            modelBuilder.Entity("Domain.Entities.StaffWorkingProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("retireStatus")
                        .HasColumnType("int");

                    b.Property<int>("totalAbsent")
                        .HasColumnType("int");

                    b.Property<int>("totalPresent")
                        .HasColumnType("int");

                    b.Property<double>("totalSalary")
                        .HasColumnType("float");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("StaffWorkingProfile");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("gender")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entities.Voucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("discountPercent")
                        .HasColumnType("float");

                    b.Property<string>("voucherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("Domain.Entities.WorkingManagement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WorkingManagement");
                });

            modelBuilder.Entity("Domain.Entities.WorkingSlotInAMonth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double?>("basicSalaryBase")
                        .HasColumnType("float");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("holidayId")
                        .HasColumnType("int");

                    b.Property<double?>("salaryCoefficientBase")
                        .HasColumnType("float");

                    b.Property<int?>("salaryCoefficientId")
                        .HasColumnType("int");

                    b.Property<int>("slotHour")
                        .HasColumnType("int");

                    b.Property<double?>("slotSalary")
                        .HasColumnType("float");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("workingManagementId")
                        .HasColumnType("int");

                    b.Property<int>("workingStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("holidayId");

                    b.HasIndex("salaryCoefficientId");

                    b.HasIndex("workingManagementId");

                    b.ToTable("WorkingSlotInAMonth");
                });

            modelBuilder.Entity("Domain.EntitiesRelationship.ReservationDetail", b =>
                {
                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("CourtId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ReservationId", "CourtId");

                    b.HasIndex("CourtId");

                    b.ToTable("ReservationDetail");
                });

            modelBuilder.Entity("Domain.EntitiesRelationship.UserSlot", b =>
                {
                    b.Property<int>("workingSlotInAMonthId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int>("AttendanceStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("workingSlotInAMonthId", "userId");

                    b.HasIndex("userId");

                    b.ToTable("UserSlot");
                });

            modelBuilder.Entity("Domain.Entities.AbsentRequest", b =>
                {
                    b.HasOne("Domain.Entities.User", "Users")
                        .WithMany("AbsentRequests")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.Furlough", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Furloughs")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Domain.Entities.Holidays", "Holiday")
                        .WithMany("Reservation")
                        .HasForeignKey("holidayId");

                    b.HasOne("Domain.Entities.Payment", "Payment")
                        .WithMany("Reservations")
                        .HasForeignKey("paymentId");

                    b.HasOne("Domain.Entities.User", "Users")
                        .WithMany("Reservations")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Voucher", "Voucher")
                        .WithMany("Reservations")
                        .HasForeignKey("voucherId");

                    b.Navigation("Holiday");

                    b.Navigation("Payment");

                    b.Navigation("Users");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("Domain.Entities.StaffWorkingProfile", b =>
                {
                    b.HasOne("Domain.Entities.User", "Users")
                        .WithMany("StaffWorkingProfiles")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.WorkingSlotInAMonth", b =>
                {
                    b.HasOne("Domain.Entities.Holidays", "Holiday")
                        .WithMany("WorkingSlotInAMonth")
                        .HasForeignKey("holidayId");

                    b.HasOne("Domain.Entities.SalaryCoefficient", "SalaryCoefficient")
                        .WithMany("WorkingSlotInAMonth")
                        .HasForeignKey("salaryCoefficientId");

                    b.HasOne("Domain.Entities.WorkingManagement", "WorkingManagement")
                        .WithMany("WorkingSlotInAMonth")
                        .HasForeignKey("workingManagementId");

                    b.Navigation("Holiday");

                    b.Navigation("SalaryCoefficient");

                    b.Navigation("WorkingManagement");
                });

            modelBuilder.Entity("Domain.EntitiesRelationship.ReservationDetail", b =>
                {
                    b.HasOne("Domain.Entities.Court", "Court")
                        .WithMany("ReservationDetails")
                        .HasForeignKey("CourtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Reservation", "Reservation")
                        .WithMany("ReservationDetails")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Court");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Domain.EntitiesRelationship.UserSlot", b =>
                {
                    b.HasOne("Domain.Entities.User", "Users")
                        .WithMany("UserSlots")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.WorkingSlotInAMonth", "WorkingSlotInAMonth")
                        .WithMany("UserSlot")
                        .HasForeignKey("workingSlotInAMonthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");

                    b.Navigation("WorkingSlotInAMonth");
                });

            modelBuilder.Entity("Domain.Entities.Court", b =>
                {
                    b.Navigation("ReservationDetails");
                });

            modelBuilder.Entity("Domain.Entities.Holidays", b =>
                {
                    b.Navigation("Reservation");

                    b.Navigation("WorkingSlotInAMonth");
                });

            modelBuilder.Entity("Domain.Entities.Payment", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.Navigation("ReservationDetails");
                });

            modelBuilder.Entity("Domain.Entities.SalaryCoefficient", b =>
                {
                    b.Navigation("WorkingSlotInAMonth");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("AbsentRequests");

                    b.Navigation("Furloughs");

                    b.Navigation("Reservations");

                    b.Navigation("StaffWorkingProfiles");

                    b.Navigation("UserSlots");
                });

            modelBuilder.Entity("Domain.Entities.Voucher", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Domain.Entities.WorkingManagement", b =>
                {
                    b.Navigation("WorkingSlotInAMonth");
                });

            modelBuilder.Entity("Domain.Entities.WorkingSlotInAMonth", b =>
                {
                    b.Navigation("UserSlot");
                });
#pragma warning restore 612, 618
        }
    }
}
