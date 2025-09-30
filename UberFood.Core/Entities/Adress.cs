using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberFood.Core.Entities;

public class Adress
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(150)]
    [Column("Street")]
    public string Street { get; set; } = string.Empty;
    [Required]
    [MaxLength(150)]
    [Column("City")]
    public string City { get; set; } = string.Empty;
    [Required]
    [MaxLength(150)]
    [Column("State")]
    public string State { get; set; } = string.Empty;
    [Required]
    [MaxLength(5)]
    [Column("Zip")]
    public string Zip { get; set; } = string.Empty;
    [Required]
    [MaxLength(150)]
    [Column("Country")]
    public string Country { get; set; } = string.Empty;
}
