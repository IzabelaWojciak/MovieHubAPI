using System.ComponentModel.DataAnnotations;

namespace MovieHubClientMockChallenge.Models;

public class PrincessTheatreMovieDto
{
    [Required]
    public string Id { get; set; } = String.Empty;

    [Required]
    public string Title { get; set; } = String.Empty;

    [Required]
    public string Type { get; set; } = String.Empty;

    [Required]
    public string Poster { get; set; } = String.Empty;

    [Required]
    public string Actors { get; set; } = String.Empty;

    [Required]
    public double Price { get; set; }
}