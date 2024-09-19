using MovieHubClientMockChallenge.Entities;

namespace MovieHubClientMockChallenge.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMoviesAsync(
        string? title,
        string? genre
    );

    Task<Movie?> GetMovieAsync(int id);

    Task<MovieReview?> GetReviewAsync(int id);

    Task<IEnumerable<MovieReview>> GetReviewsByMovieAsync(int movieId);

    Task<MovieReview?> GetReviewAsync(int movieId, int reviewId);

    void CreateReviewForMovieAsync(Movie movie, MovieReview movieReview);
    
    void DeleteReviewAsync(MovieReview movieReview);

    Task<decimal> GetAverageScore(int movieId);

    Task<bool> MovieExistsAsync(int movieId);
    
    Task<bool> SaveChangesAsync();
}