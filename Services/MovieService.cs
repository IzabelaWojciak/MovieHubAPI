using AutoMapper;
using MovieHubClientMockChallenge.Models;
using MovieHubClientMockChallenge.Repositories;

namespace MovieHubClientMockChallenge.Services;

public class MovieService(IMovieRepository movieRepository, IMapper mapper, PrincessTheatreService princessTheatreService)
{
    private readonly IMovieRepository _movieRepository = movieRepository  ?? throw new ArgumentNullException(nameof(movieRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<IEnumerable<MovieDto>> GetMovies(
        string? title,
        string? genre
    )
    {
        var movieEntities = await _movieRepository.GetMoviesAsync(title, genre);
        var movies = _mapper.Map<IEnumerable<MovieDto>>(movieEntities).ToList();
    
        var tasks = movies.Select(async movieDto =>
        {
            movieDto.AverageScore = await _movieRepository.GetAverageScore(movieDto.Id);
            return movieDto;
        });
    
        await Task.WhenAll(tasks);
        return movies;
    }

    public async Task<MovieDto> GetMovieById(int movieId)
    {
        var movieEntity = await _movieRepository.GetMovieAsync(movieId);
        var movieDto = _mapper.Map<MovieDto>(movieEntity);
        movieDto.AverageScore = await _movieRepository.GetAverageScore(movieId);
        
        List<CinemaDto> princessTheatreCinemas = await princessTheatreService.GetCinemasByReferenceIdAsync(movieEntity?.PrincessTheatreMovieId);

        foreach (CinemaDto princessTheatreCinema in princessTheatreCinemas)
        {
            movieDto.Cinemas.Add(princessTheatreCinema);
        }

        return movieDto;
    }
}