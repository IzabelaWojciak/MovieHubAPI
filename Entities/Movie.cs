using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieHubClientMockChallenge.Entities;

[Table("Movie")]
public class Movie(
    string title,
    DateTime releaseDate,
    string genre,
    int runtime,
    string synopsis,
    string director,
    string rating)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; init; }
    
    [Required]
    [MaxLength(128)]
    [Column("title")]
    public string Title { get; init; } = title;

    [Required]
    [Column("releaseDate")]
    public DateTime ReleaseDate { get; init; } = releaseDate;

    [Required]
    [MaxLength(64)]
    [Column("genre")]
    public string Genre { get; init; } = genre;

    [Required]
    [Column("runtime")]
    public int Runtime { get; init; } = runtime;

    [Required]
    [Column("synopsis")]
    public string Synopsis { get; init; } = synopsis;

    [Required]
    [MaxLength(64)]
    [Column("director")]
    public string Director { get; init; } = director;

    [Required]
    [MaxLength(8)]
    [Column("rating")]
    public string Rating { get; init; } = rating;

    public ICollection<MovieCinema> MovieCinemas { get; init; } = new List<MovieCinema>();
    public ICollection<MovieReview> MovieReviews{ get; init; } = new List<MovieReview>();
}