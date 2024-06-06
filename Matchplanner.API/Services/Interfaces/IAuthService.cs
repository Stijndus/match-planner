using Matchplanner.Shared.Models;

namespace Matchplanner.WebApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserModel?> Login(string email, string password);
        Task Register(UserModel user);
    }
}
