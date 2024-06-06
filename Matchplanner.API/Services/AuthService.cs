using Matchplanner.Shared.Models;
using Matchplanner.WebApi;
using Microsoft.EntityFrameworkCore;

namespace Matchplanner.API.Services
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto loginDto, CancellationToken cancellationToken = default);
    }

    public class AuthService(IDbContextFactory<MatchplannerContext> dbFactory)
    {
        public async Task<UserModel?> Login(string Email, string Password)
        {
            var dbContext = await dbFactory.CreateDbContextAsync();

            dbContext.EnsureSeedData();

            return await dbContext.Users.SingleOrDefaultAsync(m => (m.Email == Email) & (m.Password == Password));
        }


        public async Task Register(UserModel user)
        {
            var dbContext = await dbFactory.CreateDbContextAsync();

            dbContext.EnsureSeedData();

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}