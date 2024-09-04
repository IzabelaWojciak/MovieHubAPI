using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Mvc;
using MovieHubClientMockChallenge.Models;
using MovieHubClientMockChallenge.Repositories;
using MovieHubClientMockChallenge.Services;

namespace MovieHubClientMockChallenge.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController(MovieService movieService) : ControllerBase
{
    private readonly MovieService _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
    
    [HttpGet]
    public async Task<ActionResult> GetMovies(
        [FromQuery(Name = "title")] string? title,
        [FromQuery(Name = "genre")] string? genre
    )
    {
        var movies = await _movieService.GetMovies(title, genre);
        return Ok(movies);
    }

    [HttpGet("{movieId:int}")]
    public async Task<ActionResult> GetMovieById(
        int movieId
    )
    {
        var movie = await _movieService.GetMovieById(movieId);
        return Ok(movie);
    }
}