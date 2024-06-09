using Matchplanner.Shared.Models;
using Matchplanner.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Matchplanner.WebApi.Services;

    public class TeamService(IDbContextFactory<MatchplannerContext> dbFactory) : ITeamService
    {

        public async Task<List<TeamModel>> GetAllTeamsAsync()
        {
            var dbContext = await dbFactory.CreateDbContextAsync();
            // this is for an in memory db. Remove when we switch
            dbContext.EnsureSeedData();

            return await dbContext.Teams.ToListAsync();
        }

    public async Task<TeamModel?> GetTeamByIdAsync(int id)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        return await dbContext.Teams.SingleOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddTeamAsync(TeamModel Team)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        await dbContext.Teams.AddAsync(Team);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateTeamAsync(TeamModel Team)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        var currentTeam = await dbContext.Teams.FirstOrDefaultAsync(m => m.Id == Team.Id);

        currentTeam.Name = Team.Name;
        currentTeam.Description = Team.Description;
        currentTeam.ClubId = Team.ClubId;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteTeamAsync(int id)
    {
        var dbContext = dbFactory.CreateDbContext();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        var Team = await dbContext.Teams.SingleOrDefaultAsync(m => m.Id == id);

        if (Team is null)
        {
            return;
        }

        dbContext.Teams.Remove(Team);

        await dbContext.SaveChangesAsync();
    }
}

