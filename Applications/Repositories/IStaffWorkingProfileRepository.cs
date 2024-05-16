using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Repositories
{
    public interface IStaffWorkingProfileRepository : IGenericRepository<StaffWorkingProfile>
    {
        Task<StaffWorkingProfile> GetStaffWorkingProfileByUserId(int UserId);

        public interface IStaffWorkingProfileRepository : IGenericRepository<StaffWorkingProfile>
        {
            public Task<List<StaffWorkingProfile>> Get(int id);
        }
    }
}
