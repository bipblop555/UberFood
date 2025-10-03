using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UberFood.Web.Services;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.ViewsModel.Order;
using UberFood.Web.ViewsModel.OrderProducts;



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
           

        }).ToList();

        return View(viewModelList);
    }

    public async Task<IActionResult> Details([FromRoute]Guid id)
    {
        var order = await _ordersService.GetOrderByIdAsync(id);
 
        var productViewModels = order.OrderProducts
        .Select(op => new OrderProductViewModel
        {
            
            ProductName = op.ProductName,
            ProductPrice = op.ProductPrice,
        })
        .ToList()
       
        ?? new List<OrderProductViewModel>();

       
        var viewModelOrder = new OrderDetailsViewModel
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status,
            OrderProducts = productViewModels
        };

        return this.View(viewModelOrder);
    
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
    public async Task<ActionResult> Create([Bind("UserId, AddressId, ProductsIds, OrderDate, DeliveryDate, Status")] OrderCreateOrUpdateViewModel orderViewModel)
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
                UserId = orderViewModel.UserId,
                AddressId = orderViewModel.AddressId,
                Status = orderViewModel.Status,
                DeliveryDate = orderViewModel.DeliveryDate,
                OrderDate = orderViewModel.OrderDate,
                OrderProducts = orderViewModel.ProductsIds.Select(pid => new OrderProductDto
                {
                    ProductsId = pid
                }).ToList()

                //OrderProducts = new List<OrderProductDto>
                //{
                //    new OrderProductDto
                //    {
                //        ProductsId = orderViewModel.ProductId,
                //    }
                //}
            };

            await _ordersService.CreateOrderAsync(orderDto);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return View();
        }
    }
    // GET: Orders/Edit/{id}
    public async Task<IActionResult> Edit(Guid id)
    {
        var order = await _ordersService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        var users = await _usersService.GetUsersAsync();
        var products = await _productService.GetProductsAsync();

        var viewModel = new OrderCreateOrUpdateViewModel
        {
            Id = order.Id,
            UserId = order.UserId,
            AddressId = order.AddressId,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status,
            ProductsIds = order.OrderProducts.Select(op => op.ProductsId).ToList(),

            Users = users.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.FirstName
            }),
            Adresse = users.Select(u => u.Adresse).Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = $"{a.Street} {a.Zip} {a.City}"
            }),
            Products = products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            })
        };

        return View(viewModel);
    }
    // POST: Orders/Edit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Id, UserId, AddressId, ProductsIds, OrderDate, DeliveryDate, Status")] OrderCreateOrUpdateViewModel orderViewModel)
    {
        if (id != orderViewModel.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            var users = await _usersService.GetUsersAsync();
            var products = await _productService.GetProductsAsync();

            orderViewModel.Users = users.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.FirstName });
            orderViewModel.Adresse = users.Select(u => u.Adresse).Select(a => new SelectListItem { Value = a.Id.ToString(), Text = $"{a.Street} {a.Zip} {a.City}" });
            orderViewModel.Products = products.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });

            return View(orderViewModel);
        }

        try
        {
            var orderDto = new OrdersDto
            {
                Id = orderViewModel.Id,
                UserId = orderViewModel.UserId,
                AddressId = orderViewModel.AddressId,
                OrderDate = orderViewModel.OrderDate,
                DeliveryDate = orderViewModel.DeliveryDate,
                Status = orderViewModel.Status,
                OrderProducts = orderViewModel.ProductsIds.Select(pid => new OrderProductDto
                {
                    ProductsId = pid
                }).ToList()
            };

            await _ordersService.UpdateOrderrAsync(orderDto.Id,orderDto);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(orderViewModel);
        }
    }

    // GET: Orders/Delete/{id}
    public async Task<IActionResult> Delete(Guid id)
    {
        var order = await _ordersService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        var viewModel = new OrderDetailsViewModel
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status
        };

        return View(viewModel);
    }

    // POST: Orders/DeleteConfirmed
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        try
        {
            await _ordersService.DeleteOrderAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View("Error");
        }
    }
}
