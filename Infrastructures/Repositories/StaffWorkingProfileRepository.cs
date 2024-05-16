using Applications;
using Applications.Repositories;
using Applications.ViewModels.Court;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class StaffWorkingProfileRepository : GenericRepository<StaffWorkingProfile>, IStaffWorkingProfileRepository
    {
        private readonly AppDBContext _dbContext;
        public StaffWorkingProfileRepository(AppDBContext appDBContext) : base(appDBContext)
        {
            _dbContext = appDBContext;
        }
        public async Task<StaffWorkingProfile> GetStaffWorkingProfileByUserId(int UserId)
        {
            return await _dbContext.StaffWorkingProfile.FirstOrDefaultAsync(x => x.userId == UserId);
        }
        public async Task<List<StaffWorkingProfile>> Get(int id)
        {
            return await _dbSet.Where(x => x.userId == id).ToListAsync();
        }
    }
}