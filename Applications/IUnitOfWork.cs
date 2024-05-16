
using Applications.Repositories;

namespace Applications
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public ICourtRepository CourtRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IVoucherRepository VoucherRepository { get; }
        public IReservationRepository ReservationRepository { get; }
        public IHolidayRepository HolidayRepository { get; }
        public IBasicSalaryRepository BasicSalaryRepository { get; }
        public IStaffWorkingProfileRepository StaffWorkingProfileRepository { get; }
        public IWorkingManagementRepository WorkingManagementRepository { get; }
        public IWorkingSlotInAMonthRepository WorkingSlotInAMonthRepository { get; }
        public ISalaryCoefficientRepository SalaryCoefficientRepository { get; }
        public IFurloughRepository FurloughRepository { get; }
        public IAbsentRequestRepository AbsentRequestRepository { get; }
        public IUserSlotRepository UserSlotRepository { get; }
        public IReservationDetailRepository ReservationDetailRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
