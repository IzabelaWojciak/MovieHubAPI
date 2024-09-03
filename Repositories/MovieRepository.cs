using Microsoft.EntityFrameworkCore;
using MovieHubClientMockChallenge.DBContexts;
using MovieHubClientMockChallenge.Entities;
using MovieHubClientMockChallenge.Services;

namespace MovieHubClientMockChallenge.Repositories;

public class MovieRepository(MovieHubContext context) : IMovieRepository
{
    private readonly MovieHubContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<IEnumerable<Movie>> GetMoviesAsync(
        string? title,
        string? genre
    )
    {
        var movies = _context.Movies as IQueryable<Movie>;
        
        if (!string.IsNullOrWhiteSpace(title))
        {
            title = title.Trim();
            movies = movies.Where(movie => movie.Title.ToLower().Contains(title.ToLower()));
        }
        
        if (!string.IsNullOrWhiteSpace(genre))
        {
            genre = genre.Trim();
            movies = movies.Where(movie => movie.Genre.ToLower().Contains(genre.ToLower()));
        }

        return await movies.ToListAsync();
    }
}