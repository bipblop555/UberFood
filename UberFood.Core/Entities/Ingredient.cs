using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Entities;

public class Ingredient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }
    [Required]
    [MaxLength(150)]
    [Column("Name")]
    public string Name { get; set; }
    
    [Column("BurgerId")]
    public int? BurgerId { get; set; }
    [Column("PizzaId")]
    public int? PizzaId { get; set; }
    [Column("KCal")]
    public double KCal { get; set; }
    public Burger Burger { get; internal set; }
    public Pizza Pizza { get; internal set; }
}
