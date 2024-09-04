using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieHubClientMockChallenge.Entities;

[Table("Cinema")]
public class Cinema(
    string name, 
    string location)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; init; }

    [Required] [MaxLength(64)] [Column("name")]
    public string Name { get; init; } = name;

    [Required] [MaxLength(64)] [Column("location")]
    public string Location { get; init; } = location;
}