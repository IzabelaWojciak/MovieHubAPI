using MovieHubClientMockChallenge.Entities;
using MovieHubClientMockChallenge.Models;

namespace MovieHubClientMockChallenge.Profile;

public class MovieReviewProfile : AutoMapper.Profile
{
    public MovieReviewProfile()
    {

        CreateMap<MovieReview, MovieReviewDto>();
        CreateMap<MovieReviewDto, MovieReview>();
        CreateMap<MovieReviewForCreationDto, MovieReview>();
        CreateMap<MovieReviewForUpdateDto, MovieReview>();
    }
}