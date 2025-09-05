using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class OrderProductDto
{
    public OrderProductDto(int orderId, int productId)
    {
        OrderId = orderId;
        ProductId = productId;
     }

    public int OrderId { get; set; }
    public int ProductId { get; set; }
}
