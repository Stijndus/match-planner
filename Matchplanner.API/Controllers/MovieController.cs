using Matchplanner.Shared.Models;
using Matchplanner.WebApi.Services;
using Matchplanner.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Matchplanner.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController(IMovieService movieService) : ControllerBase
{
    [HttpGet("/Movie")]
    public async Task<ActionResult<List<MovieModel>>> GetAllMoviesAsync()
    {
        return await movieService.GetAllMoviesAsync();
    }

    [HttpGet("/Movie/{id}")]
    public async Task<ActionResult<MovieModel>?> GetMovieAsync(int id)
    {
        var movie = await movieService.GetMovieByIdAsync(id);

        return movie;
    }

    [HttpPost("/Movie")]
    public async Task<ActionResult<MovieModel>> AddMovieAsync([FromBody] MovieModel movie)
    {
        await movieService.AddMovieAsync(movie);

        return movie;
    }

    [HttpPut("/Movie")]
    public async Task<ActionResult<MovieModel>> UpdateMovieAsync([FromBody] MovieModel movie)
    {
        await movieService.UpdateMovieAsync(movie);

        return movie;
    }

    [HttpDelete("/Movie/{id}")]
    public async Task<ActionResult> DeleteMovieAsync(int id)
    {
        await movieService.DeleteMovieAsync(id);

        return Accepted();
    }
}
