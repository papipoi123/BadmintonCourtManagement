using Applications;
using Applications.Commons;
using Applications.Interfaces;
using Applications.Repositories;
using Applications.Services;
using Infrastructures.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services, AppConfiguration appConfiguration, IConfiguration config)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICourtService, CourtService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IVoucherService, VoucherService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IHolidayService, HolidayService>();
            services.AddScoped<IBasicSalaryService, BasicSalaryService>();
            services.AddScoped<IStaffWorkingProfileService, StaffWorkingProfileService>();
            services.AddScoped<IWorkingManagementService, WorkingManagementService>();
            services.AddScoped<IWorkingSlotInAMonthService, WorkingSlotInAMonthService>();
            services.AddScoped<ISalaryCoefficientService, SalaryCoefficientService>();
            services.AddScoped<IFurloughService, FurloughService>();
            services.AddScoped<IAbsentRequestService, AbsentRequestService>();
            services.AddScoped<IUserSlotService, UserSlotService>();
            services.AddScoped<IReservationDetailService, ReservationDetailService>();
            // local; DBName:
            //services.AddDbContext<AppDBContext>(option => option.UseSqlServer(appConfiguration.DatabaseConnection));
            services.AddDbContext<AppDBContext>(op => op.UseSqlServer(appConfiguration.DatabaseConnection));
            // Add Object Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
