using Matchplanner.Shared.Models;
using Matchplanner.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Matchplanner.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController : ControllerBase
{
    private readonly IMovieService _movieService;

    public SearchController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public ActionResult<List<MovieModel>> SearchMovies(string searchTerm, string filterValue)
    {
        var allMovies = _movieService.GetAllMoviesAsync().Result;

        if (string.IsNullOrEmpty(searchTerm) && string.IsNullOrEmpty(filterValue))
        {
            return allMovies;
        }

        List<MovieModel> filteredMovies = new List<MovieModel>();

        switch (filterValue)
        {
            case "Title":
                filteredMovies = allMovies.Where(movie => string.IsNullOrEmpty(searchTerm) || movie.Title.ToLower().Contains(searchTerm.ToLower())).ToList();
                break;
            case "Genre":
                filteredMovies = allMovies.Where(movie => string.IsNullOrEmpty(searchTerm) || movie.Genre.ToLower().Contains(searchTerm.ToLower())).ToList();
                break;
            case "Is3D":
                bool is3D = searchTerm.ToLower() == "true";
                filteredMovies = allMovies.Where(movie => movie.Is3D == is3D).ToList();
                break;
            case "ViewerGuide":
                filteredMovies = allMovies.Where(movie => string.IsNullOrEmpty(searchTerm) || movie.ViewerGuide.ToLower().Contains(searchTerm.ToLower())).ToList();
                break;
            default:
                filteredMovies = allMovies.Where(movie => string.IsNullOrEmpty(searchTerm) || movie.Title.ToLower().Contains(searchTerm.ToLower())).ToList();
                break;
        }

        return filteredMovies;
    }
}
