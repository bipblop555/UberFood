using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using UberFood.Web.Services;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Dtos;
using UberFood.Web.Services.Services;
using UberFood.Web.ViewsModel.Drinks;
using UberFood.Web.ViewsModel.Ingredients;
using UberFood.Web.ViewsModel.Order;
using UberFood.Web.ViewsModel.Pizza;

namespace UberFood.Web.Controllers;

public class OrdersController : Controller
{
    private readonly IOrdersService _ordersService;
    private readonly IUsersService _usersService;
    private readonly IProductService _productService;
    public OrdersController(IOrdersService ordersService, IUsersService usersService, IProductService productService)
    {
        this._ordersService = ordersService;
        this._usersService = usersService;
        this._productService = productService;
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

    public async Task<IActionResult> Details(Guid id)
    {
        return this.View();
    }

    // GET: OrdersController/Create
    public async Task<ActionResult> Create()
    {
        var users = await _usersService.GetUsersAsync();
        var products = await _productService.GetProductsAsync();

        var vm = new OrderCreateOrUpdateViewModel
        {
            Users = users.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.FirstName,
            }),

            Adresse = users.Select(u => u.Adresse)
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = $"{a.Street} {a.Zip} {a.City}",
                }),

            Products = products
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }),
        };
        return View(vm);
    }

    // POST: DrinksController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("UserId, AddressId, ProductId, OrderDate, DeliveryDate, Status, Products")] OrderCreateOrUpdateViewModel orderViewModel)
    {
        if (!this.ModelState.IsValid)
        {
            var users = await _usersService.GetUsersAsync();
            var products = await _productService.GetProductsAsync();

            orderViewModel.Users = users
                        .Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.FirstName });
            orderViewModel.Products = products
                    .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });
            orderViewModel.Adresse = users.Select(u => u.Adresse)
                    .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = $"{a.Street} {a.Zip} {a.City}" });
        }
        try
        {
            var orderDto = new OrdersDto
            {
                Id = Guid.NewGuid(),
                UserId = orderViewModel.UserId,
                AddressId = orderViewModel.AddressId,
                Status = orderViewModel.Status,
                DeliveryDate = orderViewModel.DeliveryDate,
                OrderDate = orderViewModel.OrderDate,
                OrderProduct = new OrderProductDto
                {
                    ProductsId = orderViewModel.ProductId,
                }
            };

            await _ordersService.CreateOrderAsync(orderDto);
            return RedirectToAction(nameof(Index));

        } catch(Exception ex)
        {
            return View();
        }
    }

}
