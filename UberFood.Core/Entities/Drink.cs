using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
