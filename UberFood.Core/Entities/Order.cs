using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberFood.Core.Entities;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public Guid Id { get; set; }

    [ForeignKey("UserId")]
    [Column("UserId")]
    public Guid UserId { get; set; }

    [ForeignKey("AddressId")]
    [Column("DeliveryAddressId")]
    public Guid AddressId { get; set; }

    [Required]
    [Column("OrderDate")]
    public DateTime OrderDate { get; set; }

    [Required]
    [Column("DeliveryTime")]
    public DateTime DeliveryDate { get; set; }
    [Required]
    [Column("Status")]
    public int Status { get; set; }
    public List<OrderProduct> OrderProducts { get; set; } = new();
}
