using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Dtos;
using UberFood.Web.ViewsModel.Ingredients;
using UberFood.Web.ViewsModel.Pizza;

namespace UberFood.Web.Controllers
{
    public class PizzasController : Controller
    {
        private readonly IPizzaService _pizzaService;
        public PizzasController(IPizzaService pizzaService)
        {
            this._pizzaService = pizzaService;
        }
        // GET: PizzasController
        public async Task<ActionResult> Index()
        {
            var pizza = await _pizzaService.GetPizzasAsync();
            return View(pizza.Select(p => new PizzaDetailsViewModel
            {
                Dough = p.Dough,
                Ingredients = p.Ingredients,
                Name = p.Name,
                Price = p.Price,
                Id = p.Id,
                IsVegetarian = p.IsVegetarian,
                ContainAlergene = p.ContainAlergene
            }));
        }

        // GET: PizzasController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var pizza = await _pizzaService.GetPizzaByIdAsync(id);
            if (pizza is null)
                return NotFound();

            var vm = new PizzaDetailsViewModel
            {
                Dough = pizza.Dough,
                DoughName = pizza.Dough.Name,
                Ingredients = pizza.Ingredients,
                Name = pizza.Name,
                Price = pizza.Price,
                Id = pizza.Id,
                IsVegetarian = pizza.IsVegetarian,
                ContainAlergene = pizza.ContainAlergene
            };

            return View(vm);
        }

        //// GET: DrinksController/Create
        public ActionResult Create()
        {
            ViewBag.Doughs = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem { Value = "A7A21DDE-CB1E-4204-4541-08DE00C02C17", Text = "Classique" },
                    new SelectListItem { Value = "A88A7238-147A-4341-4542-08DE00C02C17", Text = "Fine" },
                    new SelectListItem { Value = "D98FCCAB-A173-4169-4543-08DE00C02C17", Text = "Épaisse" }
                }, "Value", "Text");

            var pizzaCreateViewModel = new PizzaCreateOrUpdateViewModel();
            return View(pizzaCreateViewModel);
        }

        //// POST: DrinksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Name, Price, DoughId, IsVegetarian, ContainAlergene, Ingredients")] PizzaCreateOrUpdateViewModel pizzaCreateViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                ViewBag.Doughs = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem { Value = "A7A21DDE-CB1E-4204-4541-08DE00C02C17", Text = "Classique" },
                    new SelectListItem { Value = "A88A7238-147A-4341-4542-08DE00C02C17", Text = "Fine" },
                    new SelectListItem { Value = "D98FCCAB-A173-4169-4543-08DE00C02C17", Text = "Épaisse" }
                }, "Value", "Text");
                return this.View(pizzaCreateViewModel);
            }

            try
            {
                var newPizza = new PizzaDto()
                {
                    DoughId = pizzaCreateViewModel.DoughId,
                    Name = pizzaCreateViewModel.Name,
                    Price = pizzaCreateViewModel.Price,
                    IsVegetarian = pizzaCreateViewModel.IsVegetarian,
                    ContainAlergene = pizzaCreateViewModel.ContainAlergene,
                    Ingredients = pizzaCreateViewModel.Ingredients.Select(i => new IngredientDto
                    {
                        KCal = i.KCal,
                        Name = i.Name,
                    }).ToList() 
                };
                await this._pizzaService.CreatePizzaAsync(newPizza);
                return this.RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzasController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var pizza = await _pizzaService.GetPizzaByIdAsync(id);
            if (pizza is null)
                return NotFound();

            var vm = new PizzaCreateOrUpdateViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price,
                DoughId = pizza.DoughId,
                IsVegetarian = pizza.IsVegetarian,
                ContainAlergene = pizza.ContainAlergene,
                Ingredients = pizza.Ingredients.Select(i => new IngredientsViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    KCal = i.KCal
                }).ToList() ?? new List<IngredientsViewModel>()
            };

            ViewBag.Doughs = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem { Value = "A7A21DDE-CB1E-4204-4541-08DE00C02C17", Text = "Classique" },
                    new SelectListItem { Value = "A88A7238-147A-4341-4542-08DE00C02C17", Text = "Fine" },
                    new SelectListItem { Value = "D98FCCAB-A173-4169-4543-08DE00C02C17", Text = "Épaisse" }
                }, "Value", "Text");
            return View(vm);
        }

        // POST: PizzasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, [Bind("Name, Price, DoughId, IsVegetarian, ContainAlergene, Ingredients")] PizzaCreateOrUpdateViewModel pizzaCreateOrUpdateViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                ViewBag.Doughs = new SelectList(new List<SelectListItem>
                    {
                        new SelectListItem { Value = "A7A21DDE-CB1E-4204-4541-08DE00C02C17", Text = "Classique" },
                        new SelectListItem { Value = "A88A7238-147A-4341-4542-08DE00C02C17", Text = "Fine" },
                        new SelectListItem { Value = "D98FCCAB-A173-4169-4543-08DE00C02C17", Text = "Épaisse" }
                    }, "Value", "Text");
                return this.View(pizzaCreateOrUpdateViewModel);
            }
                
            try
            {
                var editPizza = new PizzaDto()
                {
                    Name = pizzaCreateOrUpdateViewModel.Name,
                    Price = pizzaCreateOrUpdateViewModel.Price,
                    DoughId = pizzaCreateOrUpdateViewModel.DoughId,
                    IsVegetarian = pizzaCreateOrUpdateViewModel.IsVegetarian,
                    ContainAlergene = pizzaCreateOrUpdateViewModel.ContainAlergene,
                    Ingredients = pizzaCreateOrUpdateViewModel.Ingredients.Select(i => new IngredientDto
                    {
                        KCal = i.KCal,
                        Name = i.Name,
                    }).ToList()
                };
                await this._pizzaService.UpdatePizzaAsync(id, editPizza);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(pizzaCreateOrUpdateViewModel);
            }
        }


        // GET: PizzasController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var pizza = await this._pizzaService.GetPizzaByIdAsync(id);
            if (pizza is null)
            {
                return this.NotFound();
            }

            var pizzaFound = new PizzaDetailsViewModel()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price,
                Dough = pizza.Dough,
                Ingredients = pizza.Ingredients,
                IsVegetarian = pizza.IsVegetarian,
                ContainAlergene = pizza.ContainAlergene
            };
            return this.View(pizzaFound);
        }

        // POST: PizzasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            await this._pizzaService.DeletePizzaAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
