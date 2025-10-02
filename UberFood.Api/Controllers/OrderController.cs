using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberFood.Core.Context;
using UberFood.Core.Entities;

namespace UberFood.Api.Controllers;

[Controller]
[Route("/api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly DataContext _dataContext;
    public OrderController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpPost]
    public async Task<IResult> AddOrders([FromBody] Order orders)
    {
        try
        {
            var order = await _dataContext.AddAsync(orders);

            await _dataContext.SaveChangesAsync();
            return Results.Created();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetOrders()
    {
        try
        {
            var orders = await _dataContext.Orders
                .ToListAsync();

            return Results.Ok(orders);
        }
        catch (Exception e)
        {
            return Results.InternalServerError($"{e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteOrder([FromRoute] Guid id)
    {
        try
        {
            var orderToRemove = await _dataContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (orderToRemove is null)
            {
                return Results.NotFound(id);
            }
            _dataContext.Remove(orderToRemove);
            await _dataContext.SaveChangesAsync();
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.InternalServerError($"{e.Message}");
        }
    }

    [HttpGet("get-order-by-userid/{id}")]
    public async Task<IResult> GetOrdersByUser([FromRoute] Guid id)
    {
        try
        {
            var orders = await _dataContext.Orders
                .Where(o => o.UserId == id)
                .ToListAsync();

            return Results.Ok(orders);
        }
        catch (Exception e)
        {
            return Results.InternalServerError($"{e.Message}");
        }
    }

    [HttpGet("get-ongoing-order")]
    public async Task<IResult> GetEnCoursOrders()
    {
        try
        {
            var orders = await _dataContext.Orders
                .Where(o => o.Status == 1)
                .ToListAsync();

            return Results.Ok(orders);
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }
    [HttpGet("get-veggy-order")]
    public async Task<IResult> GetVeggyOrders()
    {
        try
        {
            var orders = await _dataContext.Orders
                .Where(o => o.OrderProducts
                .All(op =>
                    _dataContext.Foods
                    .Where(f => f.Id == op.ProductsId)
                    .All(f => f.IsVegetarian == true)))
                .ToListAsync();

            return Results.Ok(orders);
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateOrder([FromBody] Order updatedOrder, [FromRoute] Guid id)
    {
        try
        {
            var existingOrder = await _dataContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (existingOrder is null)
                return Results.NotFound(id);

            // Mettre à jour les champs
            if (existingOrder.AddressId != updatedOrder.AddressId)
                existingOrder.AddressId = updatedOrder.AddressId;
            if (existingOrder.DeliveryDate != updatedOrder.DeliveryDate)
                existingOrder.DeliveryDate = updatedOrder.DeliveryDate;
            if (existingOrder.Status != updatedOrder.Status)
                existingOrder.Status = updatedOrder.Status;

            await _dataContext.SaveChangesAsync();
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex.Message);
        }
    }

    [HttpPut("update-by-statusid/{orderId}")]
    public async Task<IResult> UpdateOrderStatusById([FromRoute] Guid orderId, [FromBody] int newStatusId)
    {
        try
        {
            var orders = await _dataContext.Orders
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (orders is null)
            {
                return Results.NotFound();
            }

            orders.Status = newStatusId;
            await _dataContext.SaveChangesAsync();
            return Results.Ok(orders);
        }
        catch (Exception ex)
        {
            return Results.InternalServerError($"{ex.Message}");
        }
    }

    [HttpGet("/grouped-by-user")]
    public async Task<IResult> OrdersGroupedByUser()
    {
        try
        {
            var orders = await _dataContext.Orders
                .GroupBy(o => o.UserId)
                .ToListAsync();

            return Results.Ok(orders);
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex.Message);
        }
    }
}
