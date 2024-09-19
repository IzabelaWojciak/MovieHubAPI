namespace MovieHubClientMockChallenge.Models;

public class MovieReviewForUpdateDto
{
    public decimal Score { get; init; }
    
    public string Comment { get; init; } = string.Empty;
}