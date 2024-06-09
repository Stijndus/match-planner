using Matchplanner.Shared.Models;

namespace Matchplanner.WebApi.Services.Interfaces
{
    public interface IMatchService
    {

        Task<List<MatchModel>> GetAllMatchsAsync();
        Task<MatchModel?> GetMatchByIdAsync(int id);
        Task AddMatchAsync(MatchModel Match);
        Task UpdateMatchAsync(MatchModel Match);
        Task DeleteMatchAsync(int id);
    }
}