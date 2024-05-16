using Applications.Repositories;
using Domain.Entities;
using Domain.Enums.Status;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class WorkingSlotInAMonthRepository : GenericRepository<WorkingSlotInAMonth>, IWorkingSlotInAMonthRepository
    {
        private readonly AppDBContext _dbContext;
        public WorkingSlotInAMonthRepository(AppDBContext appDBContext) : base(appDBContext)
        {
            _dbContext = appDBContext;
        }

        public async Task<List<WorkingSlotInAMonth>> Filter(DateTime start, DateTime end)
        {
            var result = await _dbSet.Where(x => x.startTime >= start && x.endTime.Date <= end).ToListAsync();
            return result;
        }
        public async Task AddListWorkingSlotInAMonthAsync(DateTime startDate, DateTime enddate)
        {
            DateTime stDay = Convert.ToDateTime(startDate);
            DateTime edDay = Convert.ToDateTime(enddate);
            TimeSpan Time = enddate - startDate;
            int TotalDays = Time.Days;
            int j = 0;
            DateTime DateATD;
            for (int i = 0; i < 6; i++)
            { 
                if (j > TotalDays)
                {
                    break;
                }
                if (i == 5)
                {
                    j = j + 3;
                    i = 0;
                    DateATD = startDate.AddDays(j - 1);
                }

                else if (startDate.DayOfWeek == DayOfWeek.Tuesday && j < 1)
                {
                    i = i + 1;
                    j = j + 1;
                    DateATD = startDate;
                }

                else if (startDate.DayOfWeek == DayOfWeek.Wednesday && j < 1)
                {
                    i = i + 2;
                    j = j + 1;
                    DateATD = startDate;
                }

                else if (startDate.DayOfWeek == DayOfWeek.Thursday && j < 1)
                {
                    i = i + 3;
                    j = j + 1;
                    DateATD = startDate;
                }


                else if (startDate.DayOfWeek == DayOfWeek.Friday && j < 1)
                {
                    i = i + 4;
                    j = j + 1;
                    DateATD = startDate;
                }

                else if (startDate.DayOfWeek == DayOfWeek.Monday && j < 1)
                {
                    i = i;
                    j = j + 1;
                    DateATD = startDate;
                }
                else
                {
                    DateATD = startDate.AddDays(j);
                    j = j + 1;

                }
                DateATD = DateATD.Date;
                int a = 7;
                for (int t = 0; t < 5; t++)
                {
                    var Atd = new WorkingSlotInAMonth();
                    double sl= 0;
                    Atd.startTime = DateATD.AddHours(a);
                    a = a + 3;
                    Atd.endTime = Atd.startTime.AddHours(3);
                    Atd.slotHour = 3;
                    Atd.workingStatus = Domain.Enums.Status.WorkingStatus.Availabale;
                    if(Atd.endTime <= DateATD.AddHours(10))
                    {
                        sl = 1.2;
                    } else if (Atd.endTime == DateATD.AddHours(13))
                    {
                        sl = 1.4;
                    }
                    else if (Atd.endTime == DateATD.AddHours(16))
                    {
                        sl = 1.6;
                    }
                    else if (Atd.endTime == DateATD.AddHours(19))
                    {
                        sl = 1.8;
                    }
                    else if (Atd.endTime == DateATD.AddHours(22))
                    {
                        sl = 2.0;
                    }
                    Atd.salaryCoefficientBase = sl;
                    Atd.basicSalaryBase = 20000;
                    Atd.workingManagementId = null;
                    Atd.salaryCoefficientId = null;
                    Atd.holidayId = null;
                    Atd.slotSalary = Atd.basicSalaryBase * Atd.salaryCoefficientBase * Atd.slotHour;
                    Atd.CreationDate = DateTime.UtcNow;
                    await _dbContext.AddAsync(Atd);
                }
            }
        }
    }
}
