using Applications;
using Applications.Repositories;
using Infrastructures.Repositories;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _appDBContext;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(AppDBContext appDBContext, IUserRepository userRepository)
        {
            _appDBContext = appDBContext;
            _userRepository = userRepository;
        }

        public IUserRepository UserRepository => _userRepository;

        public ICourtRepository CourtRepository => new CourtRepository(_appDBContext);

        public IPaymentRepository PaymentRepository => new PaymentRepository(_appDBContext);

        public IVoucherRepository VoucherRepository => new VoucherRepository(_appDBContext);

        public IReservationRepository ReservationRepository => new ReservationRepository(_appDBContext);

        public IHolidayRepository HolidayRepository => new HolidayRepository(_appDBContext);

        public IBasicSalaryRepository BasicSalaryRepository => new BasicSalaryRepository(_appDBContext);

        public IStaffWorkingProfileRepository StaffWorkingProfileRepository => new StaffWorkingProfileRepository(_appDBContext);

        public IWorkingManagementRepository WorkingManagementRepository => new WorkingManagementRepository(_appDBContext);

        public IWorkingSlotInAMonthRepository WorkingSlotInAMonthRepository => new WorkingSlotInAMonthRepository(_appDBContext);

        public ISalaryCoefficientRepository SalaryCoefficientRepository => new SalaryCoefficientRepository(_appDBContext);

        public IFurloughRepository FurloughRepository => new FurloughRepository(_appDBContext);

        public IAbsentRequestRepository AbsentRequestRepository => new AbsentRequestRepository(_appDBContext);

        public IUserSlotRepository UserSlotRepository => new UserSlotRepository(_appDBContext);

        public IReservationDetailRepository ReservationDetailRepository => new ReservationDetailRepository(_appDBContext);

        public async Task<int> SaveChangeAsync() => await _appDBContext.SaveChangesAsync();
    }
}
