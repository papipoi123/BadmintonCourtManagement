using Domain.Base;
using Domain.EntitiesRelationship;
using Domain.Enums.Gender;
using Domain.Enums.Role;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Gender gender { get; set; }
        public DateTime DOB { get; set; }
        public Role role { get; set; }
        public ICollection<Furlough?> Furloughs { get; set; }
        public ICollection<Reservation?> Reservations { get; set; }
        public ICollection<UserSlot?> UserSlots { get; set; }
        public ICollection<StaffWorkingProfile?> StaffWorkingProfiles { get; set; }
        public ICollection<AbsentRequest?> AbsentRequests { get; set; }
    }
}
