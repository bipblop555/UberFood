using Microsoft.AspNetCore.Mvc;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Dtos;
using UberFood.Web.ViewsModel.Burgers;
using UberFood.Web.ViewsModel.Ingredients;

namespace UberFood.Web.Controllers;

public class BurgersController : Controller
{
    private readonly IBurgersService _burgersService;
    public BurgersController(IBurgersService burgersService)
    {
        this._burgersService = burgersService;
    }
    // GET: DrinksController
    public async Task<ActionResult> Index()
    {
        var burger = await _burgersService.GetBurgersAsync();
        return View(burger.Select(b => new BurgersIndexViewModel
        {
            Id = b.Id,
            Name = b.Name,
            Price = b.Price,
        }));
    }

    // GET: DrinksController/Details/5
    public async Task<IActionResult> Details(Guid id)
    {
        var burger = await this._burgersService.GetBurgerByIdAsync(id);
        if (burger is null)
        {
            return this.NotFound();
        }

        var burgerFound = new BurgerDetailsViewModel
        {
            Id = burger.Id,
            Name = burger.Name,
            ContainAlergene = burger.ContainAlergene,
            Price = burger.Price,
            Ingredients = burger.Ingredients.Select(i => new IngredientsViewModel
            {
                Id = i.Id,
                Name = i.Name,
                KCal = i.KCal,
            }).ToList()
        };

        return this.View(burgerFound);
    }

    //GET: DrinksController/Create
    public ActionResult Create()
    {
        var burgerCreateVM = new BurgerCreateOrUpdateViewModel();
        return View(burgerCreateVM);
    }

    //// POST: DrinksController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("Name, Price, ContainAlergene, Ingredients")] BurgerCreateOrUpdateViewModel burgerCreateViewModel)
    {
        if (!this.ModelState.IsValid)
            return this.View(burgerCreateViewModel);
        try
        {
            var burger = new BurgerDto()
            {
                Name = burgerCreateViewModel.Name,
                Price = burgerCreateViewModel.Price,
                ContainAlergene = burgerCreateViewModel.ContainAlergene,
                Ingredients = burgerCreateViewModel.Ingredients.Select(i => new IngredientDto
                {
                    KCal = i.KCal,
                    Name = i.Name,
                })

            };
            await this._burgersService.CreateBurgerAsync(burger);
            return this.RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    //// GET: DrinksController/Edit/5
    public async Task<ActionResult> Edit(Guid id)
    {
        var burger = await this._burgersService.GetBurgerByIdAsync(id);
        if (burger == null)
        {
            return this.NotFound();
        }

        var burgerToUpdate = new BurgerCreateOrUpdateViewModel()
        {
            Name = burger.Name,
            Price = burger.Price,
            ContainAlergene = burger.ContainAlergene,
            Ingredients = burger.Ingredients.Select(i => new IngredientsCreateViewModel
            {
                Id = i.Id,
                KCal = i.KCal,
                Name = i.Name,
            }).ToList()
        };
        return View(burgerToUpdate);
    }

    //// POST: DrinksController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Guid id, [Bind("Name, Price, ContainAlergene, Ingredients")] BurgerCreateOrUpdateViewModel burgerCreateViewModel)
    {
        if (!this.ModelState.IsValid)
            return this.View(burgerCreateViewModel);
        try
        {
            var editBurger = new BurgerDto()
            {
                Name = burgerCreateViewModel.Name,
                Price = burgerCreateViewModel.Price,
                ContainAlergene = burgerCreateViewModel.ContainAlergene,
                Ingredients = burgerCreateViewModel.Ingredients.Select(i => new IngredientDto
                {
                    KCal = i.KCal,
                    Name = i.Name,
                })
            };
            await this._burgersService.UpdateBurgerAsync(id, editBurger);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    //// GET: DrinksController/Delete/5
    public async Task<ActionResult> Delete(Guid id)
    {
        var burger = await this._burgersService.GetBurgerByIdAsync(id);
        if (burger is null)
        {
            return this.NotFound();
        }

        var burgerFound = new BurgerDetailsViewModel
        {
            Id = burger.Id,
            Name = burger.Name,
            ContainAlergene = burger.ContainAlergene,
            Price = burger.Price,
            Ingredients = burger.Ingredients.Select(i => new IngredientsViewModel
            {
                Id = i.Id,
                Name = i.Name,
                KCal = i.KCal,
            }).ToList()
        };
        return this.View(burgerFound);
    }

    //// POST: DrinksController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(Guid id)
    {
        await this._burgersService.DeleteBurgerAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
