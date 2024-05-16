using Domain.Base;
using Domain.EntitiesRelationship;
using Domain.Enums.Status;

namespace Domain.Entities
{
    public class StaffWorkingProfile : BaseEntity
    {
        public int totalPresent { get; set; }
        public int totalAbsent { get; set; }
        public double totalSalary { get; set; }
        public RetireStatus retireStatus { get; set; }
        public int userId { get; set; }
        public User Users { get; set; }
    }
}
