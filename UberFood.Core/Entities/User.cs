using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }
    [Required]
    [MaxLength(150)]
    [Column("Street")]
    public string Street { get; set; }
    [Required]
    [MaxLength(150)]
    [Column("City")]
    public string City { get; set; }
    [Required]
    [MaxLength(150)]
    [Column("State")]
    public string State { get; set; }
    [Required]
    [MaxLength(150)]
    [Column("Country")]
    public string Country { get; set; }
}
