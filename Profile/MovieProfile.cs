using AutoMapper;
using MovieHubClientMockChallenge.Entities;
using MovieHubClientMockChallenge.Models;

namespace MovieHubClientMockChallenge.Profile;

public class MovieProfile : AutoMapper.Profile
{
    public MovieProfile()
    {
        CreateMap<MovieCinema, CinemaDto>()
            .ForMember(dto => dto.Name, opt => opt.MapFrom(m => m.Cinema.Name))
            .ForMember(dto => dto.Location, opt => opt.MapFrom(m => m.Cinema.Location));

        CreateMap<Movie, MovieDto>()
            .ForMember(dto => dto.Cinemas, opt => opt.MapFrom(m => m.MovieCinemas));
    }
}