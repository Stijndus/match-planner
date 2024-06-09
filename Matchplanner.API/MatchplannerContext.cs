using Matchplanner.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Matchplanner.WebApi;

    public class MatchplannerContext: DbContext
    {

    public DbSet<UserModel> Users { get; set; }
    public DbSet<TeamModel> Teams { get; set; }
    public DbSet<MatchModel> Matches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = 1, Email = "stijn@ardusit.nl", Password = "3356En81", ApiToken = "Stijn", Name = "Stijn Dusseldorp", TeamID = 1 }
            );

        modelBuilder.Entity<TeamModel>().HasData(
            new TeamModel { Id = 1, Name = "Next Volley Dordrecht H1", ClubId = 1, Description = "Het eerste team van Next Volley Dordrecht" }
            );
        modelBuilder.Entity<MatchModel>().HasData(
            new MatchModel { Id = 1, AwayId = 1, AwayScore = 0, HomeId = 2, HomeScore = 0 }
            );

    }

    public void EnsureSeedData()
    {
        if (!Users.Any()) { }
    }
    }

