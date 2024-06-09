using Matchplanner.Shared.Models;
using Matchplanner.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Matchplanner.WebApi.Services;

public class MatchService(IDbContextFactory<MatchplannerContext> dbFactory) : IMatchService
{

    public async Task<List<MatchModel>> GetAllMatchsAsync()
    {
        var dbContext = await dbFactory.CreateDbContextAsync();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        return await dbContext.Matches.ToListAsync();
    }

    public async Task<MatchModel?> GetMatchByIdAsync(int id)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        return await dbContext.Matches.SingleOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddMatchAsync(MatchModel Match)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        await dbContext.Matches.AddAsync(Match);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateMatchAsync(MatchModel Match)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        var currentMatch = await dbContext.Matches.FirstOrDefaultAsync(m => m.Id == Match.Id);

        currentMatch.HomeScore = Match.HomeScore;
        currentMatch.AwayScore = Match.AwayScore;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteMatchAsync(int id)
    {
        var dbContext = dbFactory.CreateDbContext();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        var Match = await dbContext.Matches.SingleOrDefaultAsync(m => m.Id == id);

        if (Match is null)
        {
            return;
        }

        dbContext.Matches.Remove(Match);

        await dbContext.SaveChangesAsync();
    }
}

