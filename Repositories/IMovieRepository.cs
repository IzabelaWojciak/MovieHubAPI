using MovieHubClientMockChallenge.Entities;

namespace MovieHubClientMockChallenge.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMoviesAsync(
        string? title, 
        string? genre
    );
    
    Task<Movie?> GetMovieAsync(int id);
}