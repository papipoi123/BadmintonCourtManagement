using AutoMapper;

using Applications.Commons;
using Applications.ViewModels.UserViewModels;
using Domain.Entities;
using Applications.ViewModels.Court;
using Applications.ViewModels.Payment;
using Applications.ViewModels.Voucher;
using Applications.ViewModels.Reservation;
using Applications.ViewModels.HolidayViewModels;
using Applications.ViewModels.BasicSalaryViewModels;
using Applications.ViewModels.StaffWorkingProfileViewModels;
using Applications.ViewModels.WorkingManagement;
using Applications.ViewModels.WorkingSlotInAMonth;
using Applications.ViewModels.SalaryCoefficientViewModels;
using Applications.ViewModels.FurloughViewModels;
using Applications.ViewModels.AbsentRequestViewModels;
using Domain.EntitiesRelationship;
using Applications.ViewModels.UserSlotViewModels;
using Applications.ViewModels.ReservationDetailViewModels;

namespace Infrastructures.Mappers
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Court, CourtModel>()
                .ForMember(dest => dest.AvailableStatus, opt => opt.MapFrom(src => src.AvailableStatus.ToString()))
                .ForMember(dest => dest.ReservationStatus, opt => opt.MapFrom(src => src.ReservationStatus.ToString()))
                .ReverseMap();
            CreateMap<Court, CourtDetailModel>()
                .ForMember(dest => dest.ReservationStatus, opt => opt.MapFrom(src => src.ReservationStatus.ToString()))
                .ForMember(dest => dest.AvailableStatus, opt => opt.MapFrom(src => src.AvailableStatus.ToString()))
                .ReverseMap();
            CreateMap<Payment, PaymentViewModel>().ReverseMap();
            CreateMap<Voucher, VoucherViewModel>().ReverseMap();
            CreateMap<Domain.Entities.Reservation, ReservationViewModel>().ReverseMap();
            CreateMap<Holidays, HolidayViewModel>().ReverseMap();
            CreateMap<BasicSalary, BasicSalaryViewModel>().ReverseMap();
            CreateMap<StaffWorkingProfile, StaffWorkingProfileViewModel>().ReverseMap();
            CreateMap<WorkingManagement, WorkingManagementViewModel>().ReverseMap();
            CreateMap<WorkingSlotInAMonth, WorkingSlotInAMonthViewModel>().ReverseMap();
            CreateMap<SalaryCoefficientViewModel, SalaryCoefficient>().ReverseMap();
            CreateMap<FurloughViewModel, Furlough>().ReverseMap();
            CreateMap<AbsentRequestViewModel, AbsentRequest>().ReverseMap();
            /* pagination */
            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
            CreateMap<CreateUserViewModel, User>().ReverseMap();
            CreateMap<User, UserViewModel>()
            .ForMember(dest => dest.role, opt => opt.MapFrom(src => src.role.ToString()))
            .ReverseMap();
            CreateMap<UserSlot, UserSlotViewModel>().ReverseMap();
            CreateMap<ReservationDetail, ReservationDetailViewModel>().ReverseMap();
        }
    }
}
