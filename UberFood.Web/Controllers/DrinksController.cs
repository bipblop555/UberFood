using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Dtos;
using UberFood.Web.Services.Services;
using UberFood.Web.ViewsModel.Drinks;

namespace UberFood.Web.Controllers
{
    public class DrinksController : Controller
    {
        private readonly IDrinksService _drinksService;
        public DrinksController(IDrinksService drinksService)
        {
            this._drinksService = drinksService;
        }
        // GET: DrinksController
        public async Task<ActionResult> Index()
        {
            var drinks = await _drinksService.GetDrinksAsync();
            return View(drinks.Select(d => new DrinksDetailsViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Fizzy = d.Fizzy,
                KCal = d.KCal,
                Price = d.Price,
            }));
        }

        // GET: DrinksController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var drink = await this._drinksService.GetDrinkByIdAsync(id);
            if (drink is null)
            {
                return this.NotFound();
            }

            var drinkFound = new DrinksDetailsViewModel()
            {
                Fizzy = drink.Fizzy,
                KCal = drink.KCal,
                Name = drink.Name,
                Price = drink.Price,
                Id = drink.Id,
            };
            return this.View(drinkFound);
        }

        // GET: DrinksController/Create
        public ActionResult Create()
        {
            var drinkCreateViewModel = new DrinksCreateOrUpdateViewModel();
            return View(drinkCreateViewModel);
        }

        // POST: DrinksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Fizzy, KCal, Name, Price")]DrinksCreateOrUpdateViewModel drinkCreateViewModel)
        {
            if (!this.ModelState.IsValid)
                return this.View(drinkCreateViewModel);
            try
            {
                var newDrink = new DrinksDto()
                    {
                    Fizzy = drinkCreateViewModel.Fizzy,
                    KCal = drinkCreateViewModel.KCal,
                    Name = drinkCreateViewModel.Name,
                    Price = drinkCreateViewModel.Price,
                    };
                await this._drinksService.CreateDrinkAsync(newDrink);
                return this.RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DrinksController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var drink = await this._drinksService.GetDrinkByIdAsync(id);
            if (drink == null)
            {
                return this.NotFound();
            }

            var drinkEditViewModel = new DrinksCreateOrUpdateViewModel()
            {
                Fizzy = drink.Fizzy,
                KCal = drink.KCal,
                Name = drink.Name,
                Price = drink.Price,
            };
            return View(drinkEditViewModel);
        }

        // POST: DrinksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, [Bind("Fizzy, KCal, Name, Price")] DrinksCreateOrUpdateViewModel drinksCreateOrUpdateViewModel)
        {
            if (!this.ModelState.IsValid)
                return this.View(drinksCreateOrUpdateViewModel);
            try
            {
                var editDrink = new DrinksDto() 
                {
                    Fizzy = drinksCreateOrUpdateViewModel.Fizzy,
                    KCal = drinksCreateOrUpdateViewModel.KCal, 
                    Name = drinksCreateOrUpdateViewModel.Name,
                    Price = drinksCreateOrUpdateViewModel.Price,
                };
                await this._drinksService.UpdateDrinkAsync(id, editDrink);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DrinksController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var drink =await this._drinksService.GetDrinkByIdAsync(id);
            if (drink is null)
            {
                return this.NotFound();
            }

            var drinkFound = new DrinksDetailsViewModel()
            {
                Fizzy = drink.Fizzy,
                KCal = drink.KCal,
                Name = drink.Name,
                Price = drink.Price,
                Id = drink.Id,
            };
            return this.View(drinkFound);
        }

        // POST: DrinksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
                await this._drinksService.DeleteDrinkAsync(id);
                return RedirectToAction(nameof(Index));
        }
    }
}
