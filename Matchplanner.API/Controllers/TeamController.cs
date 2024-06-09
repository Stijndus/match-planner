using Matchplanner.Shared.Models;
using Matchplanner.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

namespace Matchplanner.WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class TeamController(ITeamService teamService) : ControllerBase
{

    [HttpGet("/teams")]
    public async Task<List<TeamModel>> GetAllTeamsAsync()
    {  
        return await teamService.GetAllTeamsAsync();
    }

    [HttpGet("/teams/{id}")]
    public async Task<TeamModel?> GetTeamAsync(int id)
    {
        return await teamService.GetTeamByIdAsync(id);
    }

    [HttpPost("/teams")]
    public async Task<TeamModel> CreateTeamAsync([FromBody] TeamModel team)
    {
        await teamService.AddTeamAsync(team);

        return team;
    }

    [HttpPut("/teams")]
    public async Task<TeamModel> UpdateTeamAsync([FromBody] TeamModel team)
    {
        await teamService.UpdateTeamAsync(team);

        return team;
    }

    [HttpDelete("/teams/{id}")]
    public async Task<ActionResult> DeleteTeamAsync(int id)
    {
        await teamService.DeleteTeamAsync(id);

        return Accepted();
    }
}

