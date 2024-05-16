using Domain.Entities;
using Domain.EntitiesRelationship;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructures
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<AbsentRequest> AbsentRequest { get; set; }
        public DbSet<BasicSalary> BasicSalary { get; set; }
        public DbSet<Court> Court { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Furlough> Furlough { get; set; }
        public DbSet<Holidays> Holiday { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<SalaryCoefficient> SalaryCoefficient { get; set; }
        public DbSet<StaffWorkingProfile> StaffWorkingProfile { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<WorkingManagement> WorkingManagement { get; set; }
        public DbSet<WorkingSlotInAMonth> WorkingSlotInAMonth { get; set; }
        public DbSet<ReservationDetail> ReservationDetail { get; set; }
        public DbSet<UserSlot> UserSlot { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
