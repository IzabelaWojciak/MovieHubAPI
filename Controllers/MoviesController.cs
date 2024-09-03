using Microsoft.AspNetCore.Mvc;
using MovieHubClientMockChallenge.Models;
using MovieHubClientMockChallenge.Services;

namespace MovieHubClientMockChallenge.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController(IMovieRepository movieRepository) : ControllerBase
{
    private readonly IMovieRepository _movieRepository = movieRepository  ?? throw new ArgumentNullException(nameof(movieRepository));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies(
        [FromQuery(Name = "title")] string? title,
        [FromQuery(Name = "genre")] string? genre
        )
    {
        var movieEntities = await _movieRepository.GetMoviesAsync(title, genre);
        return Ok(movieEntities);
    }
}