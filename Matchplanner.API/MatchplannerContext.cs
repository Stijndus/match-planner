using Matchplanner.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Matchplanner.WebApi;

    public class MatchplannerContext: DbContext
    {

    public DbSet<UserModel> Users { get; set; };

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = 1, Email= "stijn@ardusit.nl", Password = "3356En81", ApiToken= "Stijn", Name= "Stijn Dusseldorp" }
            );
    }

    public void EnsureSeedData()
    {
        if (!Users.Any()) { }
    }
    }

