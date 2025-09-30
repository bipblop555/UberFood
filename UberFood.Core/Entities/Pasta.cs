using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberFood.Core.Entities;

public class Pasta : Food
{
    [Required]
    [Column("Type")]
    public int Type { get; set; }
    [Required]
    [Column("KCal")]
    public double KCal { get; set; }
}
