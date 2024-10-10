using System.Net.Http.Json;
using MovieHubClientMockChallenge.Models;

namespace MovieHubClientMockChallenge.Services;

public class PrincessTheatreService(HttpService httpService)
{
    public async Task<ProviderDto?> GetMoviesByProviderAsync(string provider)
    {
        var response = await httpService.GetRetryAsync($"{provider}/movies");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ProviderDto>();
        }
        return null;
    }

    private string FormatId(string provider, string id) => $"{provider}{id}";

    public PrincessTheatreMovieDto? FindMovie(ProviderDto providerDto, string referenceId, string provider)
    {
        return providerDto?.Movies.FirstOrDefault(m => m.Id == FormatId(provider, referenceId));
    }

    public async Task<List<CinemaDto>> GetCinemasByReferenceIdAsync(string referenceId)
    {
        var cinemas = new List<CinemaDto>();

        foreach (var providerInfo in GetAllProviders())
        {
            var providerMovies = await GetMoviesByProviderAsync(providerInfo.URLSegment);
            var movie = FindMovie(providerMovies, referenceId, providerInfo.Short);

            if (movie != null)
            {
                cinemas.Add(new CinemaDto
                {
                    Name = providerInfo.Name,
                    TicketPrice = Convert.ToDecimal(movie.Price)
                });
            }
        }

        return cinemas;
    }

    private static IEnumerable<MovieProviderInfo> GetAllProviders()
    {
        return new[] { MovieProviders.Providers.Filmworld, MovieProviders.Providers.Cinemaworld };
    }
}

public class MovieProvider
{
    public MovieProviderInfo Filmworld { get; set; } = new();
    public MovieProviderInfo Cinemaworld { get; set; } = new();
}

public class MovieProviderInfo
{
    public string Name { get; set; } = string.Empty;
    public string URLSegment { get; set; } = string.Empty;
    public string Short { get; set; } = string.Empty;
}

public static class MovieProviders
{
    public static readonly MovieProvider Providers = new()
    {
        Filmworld = new MovieProviderInfo { Name = "Filmworld", URLSegment = "filmworld", Short = "fw" },
        Cinemaworld = new MovieProviderInfo { Name = "Cinemaworld", URLSegment = "cinemaworld", Short = "cw" }
    };
}