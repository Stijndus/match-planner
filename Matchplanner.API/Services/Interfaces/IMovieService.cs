using Matchplanner.Shared.Models;

namespace Matchplanner.WebApi.Services.Interfaces;

public interface IMovieService
{
    Task<List<MovieModel>> GetAllMoviesAsync();
    Task<MovieModel?> GetMovieByIdAsync(int id);
    Task AddMovieAsync(MovieModel movie);
    Task UpdateMovieAsync(MovieModel movie);
    Task DeleteMovieAsync(int id);
}