using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Context;
using UberFood.Core.Entities;
using UberFood.Core.Models;

namespace UberFood.Core.Handlers;

public class Orderhandler
{

    public void AddOrders(OrdersDto orders)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var orderToAdd = new Entities.Order
                {
                    UserId = orders.UserId,
                    AdressId = orders.AdressId,
                    DeliveryDate = orders.DelivryDate,
                    OrderDate = orders.OrderDate,
                    Status = orders.Status
                };

                ctx.Add(orderToAdd);
                ctx.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public List<OrdersDto> GetOrders()
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var orders = ctx.Orders
                    .Select(o => new OrdersDto(o.UserId, o.AdressId, o.DeliveryDate, o.OrderDate, o.OrderId, o.Status))
                    .ToList();

                return orders;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return [];
        }
    }

    public bool DeleteOrder(int id)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var orderToRemove = ctx.Orders.FirstOrDefault(o => o.OrderId == id);
                if (orderToRemove is not null)
                {
                    ctx.Remove(orderToRemove);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public List<OrdersDto> GetOrdersByUser(int id)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var orders = ctx.Orders
                    .Select(o => new OrdersDto(o.UserId, o.AdressId, o.DeliveryDate, o.OrderDate, o.OrderId, o.Status))
                    .Where(o => o.UserId == id)
                    .ToList();

                return orders;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return [];
        }
    }

    public List<OrdersDto> GetEnCoursOrders()
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var orders = ctx.Orders
                    .Select(o => new OrdersDto(o.UserId, o.AdressId, o.DeliveryDate, o.OrderDate, o.OrderId, o.Status))
                    .Where(o => o.Status == 1)
                    .ToList();

                return orders;
            }
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
            return [];
        }
    }
}
