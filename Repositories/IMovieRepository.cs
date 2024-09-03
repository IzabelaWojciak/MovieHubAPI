using MovieHubClientMockChallenge.Entities;

namespace MovieHubClientMockChallenge.Services;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMoviesAsync(
        string? title, 
        string? genre
    );
}