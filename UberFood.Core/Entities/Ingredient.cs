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
    [ForeignKey("BurgerId")]
    [Column("BurgerID")]
    public int BurgerId { get; set; }
    [ForeignKey("PizzaId")]
    [Column("PizzaID")]
    public int PizzaId { get; set; }
}
