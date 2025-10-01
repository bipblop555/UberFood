
using Microsoft.AspNetCore.Mvc;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Dtos;
using UberFood.Web.ViewsModel.Pasta;

namespace UberFood.Web.Controllers;

public class PastaController : Controller
{
    
    private readonly IPastaService _PastaService;
    public PastaController(IPastaService PastaService)
    {
        this._PastaService = PastaService;
        
    }
    // GET: PastaController
    public async Task<ActionResult> Index()
    {
        var Pasta = await _PastaService.GetPastasAsync();
        return View(Pasta.Select(p => new PastaViewModel
        {
            Name = p.Name,
            Price = p.Price,
            IsVegetarian = p.IsVegetarian,
            ContainAlergene = p.ContainAlergene,
            Type = (PastaType)p.Type,
            KCal = p.KCal,
            Id = p.Id,
        }));
    }

    // GET: PastaController/Details/5
    public async Task<IActionResult> Details(Guid id)
    {
        var pasta = await this._PastaService.GetPastaByIdAsync(id);
        if (pasta is null)
        {
            return this.NotFound();
        }

        var pastaFound = new PastaViewModel()
        {
            Id = pasta.Id,
            Name = pasta.Name,
            KCal = pasta.KCal,
            Type = (PastaType)pasta.Type,
            Price = pasta.Price,
            IsVegetarian = pasta.IsVegetarian,
            ContainAlergene = pasta.ContainAlergene,
        };
        return this.View(pastaFound);
    }

    // GET: PastaController/Create
    public ActionResult Create()
    {
        var pastaCreateViewModel = new PastaViewModel();
        return View(pastaCreateViewModel);
    }

    // POST: PastaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("KCal, Type, Price,Name,IsVegetarian,ContainAlergene")]PastaViewModel pastaCreateViewModel)
    {
        if (!this.ModelState.IsValid)
            return this.View(pastaCreateViewModel);
        try
        {
            var newPasta = new PastaDto()
            {      
                Price = pastaCreateViewModel.Price,
                ContainAlergene = pastaCreateViewModel.ContainAlergene,
                IsVegetarian = pastaCreateViewModel.IsVegetarian,
                Name = pastaCreateViewModel.Name,
                KCal = pastaCreateViewModel.KCal,
                Type = (int)pastaCreateViewModel.Type,  
            };
            await this._PastaService.CreatePastaAsync(newPasta);
            return this.RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PastaController/Edit/5
    public async Task<ActionResult> Edit(Guid id)
    {
        var pasta = await this._PastaService.GetPastaByIdAsync(id);
        if (pasta == null)
        {
            return this.NotFound();
        }

        var pastaEditViewModel = new PastaViewModel()
        {
            Id = pasta.Id,
            Name = pasta.Name,
            KCal = pasta.KCal,
            Type = (PastaType)pasta.Type,
            Price = pasta.Price,
            IsVegetarian = pasta.IsVegetarian,
            ContainAlergene = pasta.ContainAlergene,
        };
        return View(pastaEditViewModel);
    }

    // POST: PastaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Guid id, [Bind("KCal, Type, Price,Name,IsVegetarian,ContainAlergene")] PastaViewModel pastaUpdateViewModel)
    {
        if (!this.ModelState.IsValid)
            return this.View(pastaUpdateViewModel);
        try
        {
            var editPasta = new PastaDto()
            {
                
                Name = pastaUpdateViewModel.Name,
                KCal = pastaUpdateViewModel.KCal,
                Type = (int)pastaUpdateViewModel.Type,
                Price = pastaUpdateViewModel.Price,
                IsVegetarian = pastaUpdateViewModel.IsVegetarian,
                ContainAlergene = pastaUpdateViewModel.ContainAlergene,
            };
            await this._PastaService.UpdatePastaAsync(id, editPasta);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PastaController/Delete/5
    public async Task<ActionResult> Delete(Guid id)
    {
        var pasta = await this._PastaService.GetPastaByIdAsync(id);
        if (pasta is null)
        {
            return this.NotFound();
        }

        var pastaFound = new PastaViewModel()
        {
            Id = pasta.Id,
            Name = pasta.Name,
            KCal = pasta.KCal,
            Type = (PastaType)pasta.Type,
            Price = pasta.Price,
            IsVegetarian = pasta.IsVegetarian,
            ContainAlergene = pasta.ContainAlergene,

        };
        return this.View(pastaFound);
    }

    // POST: PastaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(Guid id)
    {
        await this._PastaService.DeletePastaAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
