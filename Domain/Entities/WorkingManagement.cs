using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class WorkingManagement : BaseEntity
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public ICollection<WorkingSlotInAMonth?> WorkingSlotInAMonth { get; set; }
    }
}
