using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberFood.Core.Entities;

public class Ingredient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(150)]
    [Column("Name")]
    public string Name { get; set; } = string.Empty;
    
    [Column("BurgerId")]
    public Guid? BurgerId { get; set; }
    [Column("PizzaId")]
    public Guid? PizzaId { get; set; }
    [Column("KCal")]
    public double KCal { get; set; }
    public Burger Burger { get; set; } = null!;
    public Pizza Pizza { get; set; } = null!;
}
