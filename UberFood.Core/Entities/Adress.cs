using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Entities;

public class Adress
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(150)]
    public string Street { get; set; }
    [Required]
    [MaxLength(150)]
    public string City { get; set; }
    [Required]
    [MaxLength(150)]
    public string State { get; set; }
    [Required]
    [MaxLength(150)]
    public string Country { get; set; }
}
