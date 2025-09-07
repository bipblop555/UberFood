using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Entities;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }
    [Required]
    [Column("Name")]
    public string Name { get; set; }
    [Required]
    [Column("Price")]
    public double Price { get; set; }

    public List<Ingredient> Ingredients { get; set; }
}
