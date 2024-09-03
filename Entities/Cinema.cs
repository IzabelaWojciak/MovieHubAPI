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
    public int Id { get; set; }

    [Required] [MaxLength(64)] [Column("name")]
    public string Name { get; set; } = name;

    [Required] [MaxLength(64)] [Column("location")]
    public string Location { get; set; } = location;
}