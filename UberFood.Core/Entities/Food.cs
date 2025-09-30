using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberFood.Core.Entities;

public class Food : Product
{
    [Required]
    [Column ("IsVegetarian")]
    public bool IsVegetarian { get; set; }
    [Required]
    [Column ("ContainAlergene")] 
    public bool ContainAlergene { get; set; }
}
