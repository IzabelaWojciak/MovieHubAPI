using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieHubClientMockChallenge.Entities;

[Table("MovieCinema")]
public class MovieCinema(
    int movieId,
    int cinemaId,
    DateTime showTime,
    decimal ticketPrice
    )
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [ForeignKey("movie")] public int MovieId { get; set; } = movieId;

    [ForeignKey("cinema")] public int CinemaId { get; set; } = cinemaId;

    [Required] public DateTime ShowTime { get; set; } = showTime;

    [Required] [Precision(4, 2)] public decimal TicketPrice { get; set; } = ticketPrice;
}