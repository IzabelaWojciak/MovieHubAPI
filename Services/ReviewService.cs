using AutoMapper;
using MovieHubClientMockChallenge.Entities;
using MovieHubClientMockChallenge.Models;
using MovieHubClientMockChallenge.Repositories;

namespace MovieHubClientMockChallenge.Services;

public class ReviewService(IMovieRepository movieRepository, IMapper mapper)
{
    private readonly IMovieRepository _movieRepository = movieRepository  ?? throw new ArgumentNullException(nameof(movieRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    
    public async Task<IEnumerable<MovieReviewDto>> GetReviewsByMovieId(int movieId)
    {
        var movieReviewEntities = await _movieRepository.GetReviewsByMovieAsync(movieId);
        return _mapper.Map<IEnumerable<MovieReviewDto>>(movieReviewEntities);
    }
    
    public async Task CreateReview(int movieId, MovieReviewForCreationDto incomingReview)
    {
        var movieReview = _mapper.Map<MovieReview>(incomingReview);
        movieReview.MovieId = movieId;
        var movie = await _movieRepository.GetMovieAsync(movieId);
        _movieRepository.CreateReviewForMovieAsync(movie!, movieReview);
    }
    
    public async Task UpdateReview(int reviewId, MovieReviewForUpdateDto movieReviewForUpdate)
    {
        var movieReview = await _movieRepository.GetReviewAsync(reviewId);
        _mapper.Map(movieReviewForUpdate, movieReview);
    }
    
    public async Task DeleteReview(int movieId, int reviewId)
    {
        var movieReview = await _movieRepository.GetReviewAsync(movieId, reviewId);
        _movieRepository.DeleteReviewAsync(movieReview!);
    }
    
    public async Task<bool> MovieExists(int movieId)
    {
        return await _movieRepository.MovieExistsAsync(movieId);
    }
    
    public async Task<bool> ReviewExists(int reviewId)
    {
        return await _movieRepository.MovieExistsAsync(reviewId);
    }

    public async Task SaveChangesAsync()
    {
        await _movieRepository.SaveChangesAsync();
    }
}