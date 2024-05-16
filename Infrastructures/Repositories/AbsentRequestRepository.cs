using Applications.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class AbsentRequestRepository : GenericRepository<AbsentRequest>, IAbsentRequestRepository
    {
        public AbsentRequestRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }
    }
}