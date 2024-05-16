using Domain.Entities;

namespace Applications.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GetToken(User user);
    }
}
