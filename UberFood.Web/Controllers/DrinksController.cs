using Microsoft.AspNetCore.Mvc;
using UberFood.Web.Services.Abstractions;
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
            return View(drinks.Select(d => new DrinksIndexViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Fizzy = d.Fizzy,
                KCal = d.KCal,
                Price = d.Price,
            }));
        }

        // GET: DrinksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DrinksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrinksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DrinksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DrinksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DrinksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DrinksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
