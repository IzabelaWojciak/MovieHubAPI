namespace MovieHubClientMockChallenge.Models;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; } = string.Empty;
    public int Runtime { get; set; }
    public string Synopsis { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Rating { get; set; } = string.Empty;
    public decimal AverageScore { get; set; }

    public ICollection<CinemaDto> Cinemas { get; set; } = new List<CinemaDto>();
}