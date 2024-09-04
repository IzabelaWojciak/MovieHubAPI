namespace MovieHubClientMockChallenge.Models;

public class CinemaDto
{
    public string Name { get; set; } = String.Empty;
    public string? Location { get; set; }
    public DateTime? ShowTime { get; set; }
    public decimal TicketPrice { get; set; }
}