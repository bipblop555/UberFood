using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Context;
using UberFood.Core.Entities;
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
                    ProductsId = orderProduct.ProductsId
                };
                
                ctx.Add(orderProductToAdd);
                ctx.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    public List<OrderProductDto> GetOrderProductsByUser(int userId)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var ordersId = ctx.Orders
                    .Where(o => o.UserId == userId)
                    .Select(o => o.OrderId)
                    .ToList();

                var orderProducts =
                    (from op in ctx.OrderProducts
                     join p in ctx.Products on op.ProductsId equals p.Id
                     where ordersId.Contains(op.OrderId)
                     select new OrderProductDto(
                         op.OrderId,
                         new ProductDto(p.Name, p.Price)
                     ))
                     .ToList();

                return orderProducts;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return [];
        }
    }

    public bool RemoveOrderById(int orderID)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var orderToRemove = ctx.Orders.FirstOrDefault(o => o.OrderId == orderID);
                if(orderToRemove is not null)
                {
                    ctx.Remove(orderToRemove);
                    ctx.SaveChanges();
                }

                var orderProductToRemove = ctx.OrderProducts
                    .Where(op => op.OrderId == orderID)
                    .ToList();
                if(orderProductToRemove is not null)
                {
                    ctx.RemoveRange(orderProductToRemove);
                    ctx.SaveChanges();
                }

                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public bool UpdateOrderProducts(int orderId, List<int> newProductIds)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var order = ctx.Orders
                    .Include(o => o.OrderProducts)
                    .FirstOrDefault(o => o.OrderId == orderId);

                if (order is null)
                    return false;

                ctx.OrderProducts.RemoveRange(order.OrderProducts);

                foreach (var productId in newProductIds)
                {
                    ctx.OrderProducts.Add(new OrderProduct
                    {
                        OrderId = orderId,
                        ProductsId = productId
                    });
                }

                ctx.SaveChanges();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
