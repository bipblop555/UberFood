using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Entities;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int OrderId { get; set; }
    [ForeignKey("UserId")]
    [Column("UserId")]
    public int UserId { get; set; }
    [Required]
    [Column("OrderDate")]
    public DateTime OrderDate { get; set; }
    [Required]
    [Column("DeliveryTime")]
    public DateTime DeliveryDate { get; set; }
    [Required]
    [Column("Status")]
    public int Status { get; set; }
    [ForeignKey("AdressId")]
    [Column("DeliveryAdressId")]
    public int AdressId { get; set; }

    public List<OrderProduct> OrderProducts { get; set; } = new();

}
