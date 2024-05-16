using APIs.Services;
using APIs.Validations;
using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels.AbsentRequestViewModels;
using Applications.ViewModels.BasicSalaryViewModels;
using Applications.ViewModels.Court;
using Applications.ViewModels.FurloughViewModels;
using Applications.ViewModels.Payment;
using Applications.ViewModels.Reservation;
using Applications.ViewModels.ReservationDetailViewModels;
using Applications.ViewModels.SalaryCoefficientViewModels;
using Applications.ViewModels.StaffWorkingProfileViewModels;
using Applications.ViewModels.UserSlotViewModels;
using Applications.ViewModels.UserViewModels;
using Applications.ViewModels.Voucher;
using Applications.ViewModels.WorkingManagement;
using Applications.ViewModels.WorkingSlotInAMonth;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace APIs
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services, AppConfiguration appConfiguration)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddHttpContextAccessor();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appConfiguration.JWTSecretKey))
                };
            });

            services.AddScoped<IValidator<CourtModel>, CourtValidation>();
            services.AddScoped<IValidator<PaymentViewModel>, PaymentValidation>();
            services.AddScoped<IValidator<VoucherViewModel>, VoucherValidation>();
            services.AddScoped<IValidator<ReservationViewModel>, ReservationValidation>();
            services.AddScoped<IValidator<CreateUserViewModel>, UserValidation>();
			services.AddScoped<IValidator<BasicSalaryViewModel>, BasicSalaryValidation>();
            services.AddScoped<IValidator<StaffWorkingProfileViewModel>, StaffWorkingProfileValidation>();
            services.AddScoped<IValidator<WorkingManagementViewModel>, WorkingManagementValidation>();
            services.AddScoped<IValidator<WorkingSlotInAMonthViewModel>, WorkingSlotInAMonthValidation>();
            services.AddScoped<IValidator<SalaryCoefficientViewModel>, SalaryCoefficientValidation>();
            services.AddScoped<IValidator<FurloughViewModel>, FurloughValidation>();
            services.AddScoped<IValidator<AbsentRequestViewModel>, AbsentRequestValidator>();
            services.AddScoped<IValidator<UserSlotViewModel>, UserSlotValidation>();
            services.AddScoped<IValidator<ReservationDetailViewModel>, ReservationDetailValidation>();
            return services;
        }
    }
}
