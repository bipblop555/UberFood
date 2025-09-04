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
    [MaxLength(50)]
    [Column("FirstName")]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(50)]
    [Column("LastName")]
    public string LastName { get; set; }
    [Required]
    [MaxLength(150)]
    [Column("Phone")]
    public string Phone { get; set; }
    [Required]
    [MaxLength(150)]
    [Column("Mail")]
    public string Mail { get; set; }
    [ForeignKey("AdressId")]
    [Column("AdresseId")]
    public int AdresseId { get; set; }
}
