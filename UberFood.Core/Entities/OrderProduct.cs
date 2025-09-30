using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberFood.Core.Entities;

public class OrderProduct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public Guid Id { get; set; }

    [ForeignKey("OrderId")]
    public Guid OrderId { get; set; }

    [ForeignKey("ProductsId")]
    public Guid ProductsId { get; set; }

    //public Product Product { get; set; }
}
