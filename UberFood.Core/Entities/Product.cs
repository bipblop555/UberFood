using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberFood.Core.Entities;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public Guid Id { get; set; }
    [Required]
    [Column("Name")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [Column("Price")]
    public double Price { get; set; }

    public List<Ingredient> Ingredients { get; set; } = null!;
}
