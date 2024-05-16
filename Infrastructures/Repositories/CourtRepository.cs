using Applications.Commons;
using Applications.Repositories;
using Applications.ViewModels.Court;
using Domain.Entities;
using Domain.Enums.Status;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class CourtRepository : GenericRepository<Court>, ICourtRepository
    {
        public CourtRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }

        public async Task<CourtDetailModel?> CourtDetail(int id)
        {
            return await _dbSet.Where(x=>x.Id == id).Select(court => new CourtDetailModel
            {
                CourtCode = court.CourtCode,
                ImageURI = court.ImageURI,
                Description = court.Description,
                TotalPerson = court.TotalPerson,
                Price = court.Price,
                AvailableStatus = court.AvailableStatus.ToString(),
                ReservationStatus = court.ReservationStatus.ToString(),
                Reservations = court.ReservationDetails.Select(reservation => new Applications.ViewModels.Court.Reservation
                {
                    startTime = reservation.Reservation.startTime,
                    sendTime = reservation.Reservation.sendTime,
                    totalPrice = reservation.Reservation.totalPrice,
                    paymentType = reservation.Reservation.Payment.paymentType,
                    user = reservation.Reservation.Users.userName,
                    voucherName = reservation.Reservation.Voucher.voucherName,
                    discountPercent = reservation.Reservation.Voucher.discountPercent
                }).ToList()
            }).FirstOrDefaultAsync();
        }

        public async Task<Pagination<Court>> Filter(string? code, int? size, decimal? price, AvailableStatus? availableStatus, ReservationStatus? reservationStatus, int pageIndex = 0, int pageSize = 10)
        {
            var baseQuery = _dbSet.OrderBy(x => x.Price).AsQueryable();
            if (code is not null)
            {
                baseQuery = baseQuery.Where(x => x.CourtCode.Contains(code));
            }
            if (size is not null)
            {
                baseQuery = baseQuery.Where(x => x.TotalPerson == size);
            }
            if (price is not null)
            {
                baseQuery = baseQuery.Where(x => x.Price == price);
            }
            if (availableStatus is not null)
            {
                baseQuery = baseQuery.Where(x => x.AvailableStatus == availableStatus);
            }
            if (reservationStatus is not null)
            {
                baseQuery = baseQuery.Where(x => x.ReservationStatus == reservationStatus);
            }
            var count = baseQuery.Count();
            var result = await baseQuery.Skip(pageIndex * pageSize).Take(pageSize).AsNoTracking().ToListAsync();

            return new Pagination<Court>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = count,
                Items = result,
            };
        }
    }
}
