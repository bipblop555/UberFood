using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Abstractions;

public interface IOrdersService
{
    Task<IEnumerable<OrdersDto>> GetOrdersAsync();
    Task<OrdersDto> GetOrderByIdAsync(Guid id);
    Task CreateOrderAsync(OrdersDto order);
    Task UpdateOrderrAsync(Guid id, OrdersDto order);
    Task DeleteOrderAsync(Guid id);
}
