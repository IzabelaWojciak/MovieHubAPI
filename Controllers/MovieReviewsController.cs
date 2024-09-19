using Microsoft.AspNetCore.Mvc;
using MovieHubClientMockChallenge.Models;
using MovieHubClientMockChallenge.Services;

namespace MovieHubClientMockChallenge.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieReviewsController(ReviewService reviewService) : ControllerBase
{
    private readonly ReviewService _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));

    [HttpGet("movies/{movieId:int}")]
    public async Task<ActionResult> GetReviewsByMovieId(int movieId)
    {
       if (!await _reviewService.MovieExists(movieId)) 
       {
            return NotFound(); 
       }
       
       var reviews =  await _reviewService.GetReviewsByMovieId(movieId);
       return Ok(reviews);
    }
    
    [HttpPost("movies/{movieId:int}")]
    public async Task<ActionResult> CreateReview(int movieId, [FromBody] MovieReviewForCreationDto movieReview)
    {
        if (!await _reviewService.MovieExists(movieId)) 
        {
            return NotFound();
        }

        await _reviewService.CreateReview(movieId, movieReview);
        await _reviewService.SaveChangesAsync();
        return Created();
    }
    
    [HttpPut("movies/{movieId:int}/reviews/{reviewId:int}")]
    public async Task<ActionResult> UpdateReview(int movieId, int reviewId, [FromBody] MovieReviewForUpdateDto movieReviewForUpdate)
    {
        if (!await _reviewService.MovieExists(movieId)) 
        {
            return NotFound();
        }

        if (!await _reviewService.ReviewExists(reviewId)) 
        {
            return NotFound();
        }
       
        await _reviewService.UpdateReview(reviewId, movieReviewForUpdate);
        await _reviewService.SaveChangesAsync();

        return NoContent();
    }
    
    [HttpDelete("movies/{movieId:int}/reviews/{reviewId:int}")]
    public async Task<ActionResult> DeleteReview(int movieId, int reviewId)
    {
        if (!await _reviewService.MovieExists(movieId)) 
        {
            return NotFound();
        }
        
        if (!await _reviewService.ReviewExists(reviewId)) 
        {
            return NotFound();
        }

        await _reviewService.DeleteReview(movieId, reviewId);
        await _reviewService.SaveChangesAsync();
        return NoContent();
    }
}