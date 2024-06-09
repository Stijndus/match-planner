using Matchplanner.Shared.Models;

namespace Matchplanner.WebApi.Services.Interfaces
{
    public interface ITeamService
    {

        Task<List<TeamModel>> GetAllTeamsAsync();
        Task<TeamModel?> GetTeamByIdAsync(int id);
        Task AddTeamAsync(TeamModel team);
        Task UpdateTeamAsync(TeamModel team);
        Task DeleteTeamAsync(int id);
    }
}
