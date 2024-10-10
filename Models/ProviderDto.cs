using System.ComponentModel.DataAnnotations;

namespace MovieHubClientMockChallenge.Models;

public class ProviderDto
{

    [Required]
    public string Provider { get; set; } = String.Empty;

    public IEnumerable<PrincessTheatreMovieDto> Movies { get; set; } = new List<PrincessTheatreMovieDto>();
}