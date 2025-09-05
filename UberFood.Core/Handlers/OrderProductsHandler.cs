using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Context;
using UberFood.Core.Models;

namespace UberFood.Core.Handlers;

public class OrderProductsHandler
{
    public void AddOrderProduct(OrderProductDto orderProduct)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var orderProductToAdd = new Entities.OrderProduct
                {
                    OrderId = orderProduct.OrderId,
                    ProductsId = orderProduct.ProductId

                };

                ctx.Add(orderProductToAdd);
                ctx.SaveChanges();
            }
        } catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
       
    }

    public List<OrderProductDto> GetOrderProductsByUser(int orderId)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var ordersProductById = ctx.OrderProducts
                    .Select((p => new OrderProductDto(p.Id, p.ProductsId)))
                    .Where(p => p.OrderId == orderId)
                    .ToList();

                return ordersProductById;
            }
        } catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return [];
        }
    }
}
