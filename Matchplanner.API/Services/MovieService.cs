using Matchplanner.Database;
using Matchplanner.Shared.Models;
using Matchplanner.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Matchplanner.WebApi.Services;

public class MovieService(IDbContextFactory<MatchplannerContext> dbFactory) : IMovieService
{
    public async Task<List<MovieModel>> GetAllMoviesAsync()
    {
        var dbContext = await dbFactory.CreateDbContextAsync();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        return await dbContext.Movies.ToListAsync();
    }

    public async Task<MovieModel?> GetMovieByIdAsync(int id)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        return await dbContext.Movies.SingleOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddMovieAsync(MovieModel movie)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        await dbContext.Movies.AddAsync(movie);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateMovieAsync(MovieModel movie)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        var currentMovie = await dbContext.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);

        currentMovie.Title = movie.Title;
        currentMovie.Img = movie.Img;
        currentMovie.Rating = movie.Rating;
        currentMovie.Description = movie.Description;
        currentMovie.Director = movie.Director;
        currentMovie.Writers = movie.Writers;
        currentMovie.Cast = movie.Cast;
        currentMovie.Duration = movie.Duration;
        currentMovie.Genre = movie.Genre;
        currentMovie.Is3D = movie.Is3D;
        currentMovie.ViewerGuide = movie.ViewerGuide;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteMovieAsync(int id)
    {
        var dbContext = dbFactory.CreateDbContext();
        // this is for an in memory db. Remove when we switch
        dbContext.EnsureSeedData();

        var movie = await dbContext.Movies.SingleOrDefaultAsync(m => m.Id == id);

        if (movie is null)
        {
            return;
        }

        dbContext.Movies.Remove(movie);

        await dbContext.SaveChangesAsync();
    }
}