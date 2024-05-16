using Domain.Entities;
using Domain.EntitiesRelationship;
using Domain.Enums.Gender;

namespace Applications.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Gender gender { get; set; }
        public DateTime DOB { get; set; }
        public string role { get; set; }
        public ICollection<Furlough>? Furloughs { get; set; }
        public ICollection<Domain.Entities.Reservation>? Reservations { get; set; }
        public ICollection<UserSlot>? UserSlots { get; set; }
        public ICollection<StaffWorkingProfile>? StaffWorkingProfiles { get; set; }
        public ICollection<AbsentRequest>? AbsentRequests { get; set; }
    }
}
