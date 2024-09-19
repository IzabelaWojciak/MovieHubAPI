using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MovieHubClientMockChallenge.DBContexts;
using MovieHubClientMockChallenge.Entities;

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
    
    public async Task<Movie?> GetMovieAsync(int movieId)
    {
        return await _context.Movies
            .Include(m => m.MovieCinemas)
            .ThenInclude(mc => mc.Cinema)
            .Where(m => m.Id == movieId)
            .FirstOrDefaultAsync();
    }
    
    public async Task<MovieReview?> GetReviewAsync(int reviewId)
    {
        return await _context.MovieReviews
            .Where(movieReview => movieReview.Id == reviewId)
            .FirstOrDefaultAsync();
    }
    
    public async Task<IEnumerable<MovieReview>> GetReviewsByMovieAsync(int movieId)
    {
        return await _context.MovieReviews
            .Where(movieReview => movieReview.MovieId == movieId)
            .ToListAsync();
    }

    public async Task<MovieReview?> GetReviewAsync(int movieId, int reviewId)
    {
        return await _context.MovieReviews.FirstOrDefaultAsync(r => r.Id == reviewId && r.MovieId == movieId);
    }
    
    public void CreateReviewForMovieAsync(Movie movie, MovieReview movieReview)
    {
        movie.MovieReviews.Add(movieReview);
    }
    
    public void DeleteReviewAsync(MovieReview movieReview)
    {
        _context.MovieReviews.Remove(movieReview);
    }
    
    public async Task<decimal> GetAverageScore(int movieId)
    {
        var score = await _context.MovieReviews.Where(r => r.MovieId == movieId).SumAsync(r => (double)r.Score);
        var reviewCount = _context.MovieReviews.Count(r => r.MovieId == movieId);
        return score > 0 ? (decimal)(score / reviewCount) : 0;
    }
    
    public async Task<bool> MovieExistsAsync(int movieId)
    {
        return await _context.Movies.AnyAsync(movie => movie.Id == movieId);
    }
    
    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}