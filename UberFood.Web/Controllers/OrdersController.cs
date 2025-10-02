using Microsoft.AspNetCore.Mvc;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Services;
using UberFood.Web.ViewsModel.Ingredients;
using UberFood.Web.ViewsModel.Order;
using UberFood.Web.ViewsModel.Pizza;

namespace UberFood.Web.Controllers;

public class OrdersController : Controller
{
    private readonly IOrdersService _ordersService;
    public OrdersController(IOrdersService ordersService)
    {
        this._ordersService = ordersService;
    }
    // GET: PizzasController
    public async Task<ActionResult> Index()
    {
        var orders = await _ordersService.GetOrdersAsync();

        var viewModelList = orders.Select(order => new OrderDetailsViewModel
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status,
            ProductName = order.OrderProduct?.ProductName ?? "Produit inconnu",
            Price = order.OrderProduct?.Price ?? 0.0
        }).ToList();

        return View(viewModelList);
    }
}
