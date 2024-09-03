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
    string rating,
    string princessTheatreMovieId)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(128)]
    [Column("title")]
    public string Title { get; set; } = title;

    [Required]
    [Column("releaseDate")]
    public DateTime ReleaseDate { get; set; } = releaseDate;

    [Required]
    [MaxLength(64)]
    [Column("genre")]
    public string Genre { get; set; } = genre;

    [Required]
    [Column("runtime")]
    public int Runtime { get; set; } = runtime;

    [Required]
    [Column("synopsis")]
    public string Synopsis { get; set; } = synopsis;

    [Required]
    [MaxLength(64)]
    [Column("director")]
    public string Director { get; set; } = director;

    [Required]
    [MaxLength(8)]
    [Column("rating")]
    public string Rating { get; set; } = rating;

    [Required]
    [MaxLength(16)]
    [Column("princessTheatreMovieId")]
    public string PrincessTheatreMovieId { get; set; } = princessTheatreMovieId;
}