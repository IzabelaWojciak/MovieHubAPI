using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieHubClientMockChallenge.Models;
using MovieHubClientMockChallenge.Repositories;

namespace MovieHubClientMockChallenge.Services;

public class MovieService(IMovieRepository movieRepository, IMapper mapper)
{
    private readonly IMovieRepository _movieRepository = movieRepository  ?? throw new ArgumentNullException(nameof(movieRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<IEnumerable<MovieDto>> GetMovies(
        string? title,
        string? genre
    )
    {
        var movieEntities = await _movieRepository.GetMoviesAsync(title, genre);
        return _mapper.Map<IEnumerable<MovieDto>>(movieEntities);
    }

    public async Task<MovieDto> GetMovieById(int movieId)
    {
        var movieEntity = await _movieRepository.GetMovieAsync(movieId);
        return _mapper.Map<MovieDto>(movieEntity);
    }
}