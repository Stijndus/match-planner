using Matchplanner.Database;
using Matchplanner.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Matchplanner.WebApi.Services;

public class RoomService(IDbContextFactory<MatchplannerContext> dbFactory) : IRoomService
{
}
