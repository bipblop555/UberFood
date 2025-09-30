using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberFood.Core.Entities;

public class Drink : Product
{
    [Required]
    [Column("Fizzy")]
    public bool Fizzy { get; set; }
    [Required]
    [Column("KCal")]
    public double KCal { get; set; }
}
