using Microsoft.EntityFrameworkCore;
using MovieHubClientMockChallenge.Entities;

namespace MovieHubClientMockChallenge.DBContexts;

public class MovieHubContext(DbContextOptions<MovieHubContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; init; }
    public DbSet<Cinema> Cinemas { get; init; }
    public DbSet<MovieCinema> MovieCinemas { get; init; }
}
