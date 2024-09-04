using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieHubClientMockChallenge.Entities;

[Table("MovieCinema")]
public class MovieCinema(
    DateTime showTime,
    decimal ticketPrice,
    int movieId,
    int cinemaId
    )
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; init; }

    [ForeignKey("movieId")] public Movie? Movie { get; init; }
    
    public int MovieId { get; init; } = movieId;

    [ForeignKey("cinemaId")] public Cinema? Cinema { get; init; }
    
    public int CinemaId { get; init; } = cinemaId;

    [Required] [Column("showTime")] public DateTime ShowTime { get; init; } = showTime;

    [Required] [Precision(4, 2)] [Column("ticketPrice")] public decimal TicketPrice { get; init; } = ticketPrice;
}