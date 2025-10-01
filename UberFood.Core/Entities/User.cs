using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberFood.Core.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("FirstName")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [Column("LastName")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MinLength(8)]
    [Column("Password")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    [Column("Phone")]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    [Column("Mail")]
    public string Mail { get; set; } = string.Empty;

    [Column("AdresseId")]
    public Guid AdresseId { get; set; }
    public Adress Adresse { get; set; } = null!;

}
