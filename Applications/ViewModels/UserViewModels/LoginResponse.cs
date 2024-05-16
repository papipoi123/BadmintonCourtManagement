using Domain.Enums.Role;

namespace Applications.ViewModels.UserViewModels;

public class LoginResponse
{
    public int Id { get; set; }
    public string userName { get; set; }
    public string email { get; set; }
    public Role role { get; set; }
    public string Token { get; set; }
    public DateTime TokenExpiredAt { get; set; }

}
