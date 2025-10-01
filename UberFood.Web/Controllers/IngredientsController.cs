
using Microsoft.AspNetCore.Mvc;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Dtos;
using UberFood.Web.ViewsModel.Ingredients;

namespace UberFood.Web.Controllers;

public class IngredientsController : Controller
{
    private readonly IIngredientsService _ingredientsService;
    public IngredientsController(IIngredientsService ingredientsService)
    {
        this._ingredientsService = ingredientsService;
    }
    // GET: IngredientsController
    public async Task<ActionResult> Index()
    {
        var ingredients = await _ingredientsService.GetIngredientsAsync();
        return View(ingredients.Select(i => new IngredientsViewModel
        {
            Name = i.Name,
            KCal = i.KCal,
            Id = i.Id,
        }));
    }

    // GET: IngredientsController/Details/5
    public async Task<IActionResult> Details(Guid id)
    {
        var ingredient = await this._ingredientsService.GetIngredientByIdAsync(id);
        if (ingredient is null)
        {
            return this.NotFound();
        }

        var ingredientFound = new IngredientsViewModel()
        {
            KCal = ingredient.KCal,
            Name = ingredient.Name,
            Id = ingredient.Id,
        };
        return this.View(ingredientFound);
    }

    // GET: IngredientsController/Create
    public ActionResult Create()
    {
        var ingredientCreateViewModel = new IngredientsViewModel();
        return View(ingredientCreateViewModel);
    }

    // POST: IngredientsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("Name,KCal")]IngredientsViewModel ingredientCreateViewModel)
    {
        if (!this.ModelState.IsValid)
            return this.View(ingredientCreateViewModel);
        try
        {
            var newingredient = new IngredientDto()
            {      
                KCal = ingredientCreateViewModel.KCal,
                Name = ingredientCreateViewModel.Name,  
            };
            await this._ingredientsService.CreateIngredientAsync(newingredient);
            return this.RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: IngredientsController/Edit/5
    public async Task<ActionResult> Edit(Guid id)
    {
        var ingredient = await this._ingredientsService.GetIngredientByIdAsync(id);
        if (ingredient == null)
        {
            return this.NotFound();
        }

        var ingredientEditViewModel = new IngredientsViewModel()
        {
            KCal = ingredient.KCal,
            Name = ingredient.Name,
        };
        return View(ingredientEditViewModel);
    }

    // POST: IngredientsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Guid id, [Bind("KCal, Name")] IngredientsViewModel ingredientsUpdateViewModel)
    {
        if (!this.ModelState.IsValid)
            return this.View(ingredientsUpdateViewModel);
        try
        {
            var editingredient = new IngredientDto()
            {
                KCal = ingredientsUpdateViewModel.KCal,
                Name = ingredientsUpdateViewModel.Name,
            };
            await this._ingredientsService.UpdateIngredientAsync(id, editingredient);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: IngredientsController/Delete/5
    public async Task<ActionResult> Delete(Guid id)
    {
        var ingredient = await this._ingredientsService.GetIngredientByIdAsync(id);
        if (ingredient is null)
        {
            return this.NotFound();
        }

        var ingredientFound = new IngredientsViewModel()
        {
            KCal = ingredient.KCal,
            Name = ingredient.Name,
            Id = ingredient.Id,
        };
        return this.View(ingredientFound);
    }

    // POST: IngredientsController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(Guid id)
    {
        await this._ingredientsService.DeleteIngredientAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
