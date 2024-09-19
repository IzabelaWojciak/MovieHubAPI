using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieHubClientMockChallenge.Entities;

[Table("MovieReview")]
public class MovieReview
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; init; }
    
    [ForeignKey("movieId")] public Movie? Movie { get; init; }
    
    public int MovieId { get; set; }

    [Required] [Column("score")] public decimal Score { get; init; }

    [Required]
    [Column("comment")]
    public string Comment { get; init; } = String.Empty;

    [Required] [Column("reviewDate")] public DateTime ReviewDate { get; init; } = DateTime.Now;
}