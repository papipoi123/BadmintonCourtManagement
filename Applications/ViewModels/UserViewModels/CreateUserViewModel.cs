using Domain.Enums.Gender;

namespace Applications.ViewModels.UserViewModels;

public class CreateUserViewModel
{
    public string userName { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public Gender gender { get; set; }
    public DateTime DOB { get; set; }
}
