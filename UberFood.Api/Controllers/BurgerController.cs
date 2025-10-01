using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberFood.Core.Context;
using UberFood.Core.Entities;

namespace UberFood.Api.Controllers;

[Controller]
[Route("/api/[controller]")]
public sealed class BurgerController : ControllerBase
{
    private readonly DataContext _dataContext;
    public BurgerController(DataContext ctx)
    {
        this._dataContext = ctx;
    }

    [HttpPost]
    public async Task<IResult> AddBurger([FromBody] Burger burger)
    {
        try
        {
            await _dataContext.AddAsync(burger);
            await _dataContext.SaveChangesAsync();
            return Results.Created();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return Results.InternalServerError();
        }
    }

    [HttpGet]
    public async Task<IResult> GetBurgers()
    {
        try
        {
            var burgers = await _dataContext.Burgers
                .Include(b => b.Ingredients)
                .Select(b => new Burger
                {
                    Id = b.Id,
                    Name = b.Name,
                    Price = b.Price,
                    ContainAlergene = b.ContainAlergene,
                    Ingredients = b.Ingredients.Select(i => new Ingredient
                    {
                        Id = i.Id,
                        Name = i.Name,
                        KCal = i.KCal
                    }).ToList()
                })
                .ToListAsync();

            return Results.Ok(burgers);
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateBurger([FromRoute] Guid id, [FromBody] Burger newBurger)
    {
        try
        {
            var burgerToUpdate = await _dataContext.Burgers
                .Include(b => b.Ingredients)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (burgerToUpdate is null)
            {
                return Results.NotFound();
            }
            if (burgerToUpdate.Name != newBurger.Name)
                burgerToUpdate.Name = newBurger.Name;
            if (burgerToUpdate.Price != newBurger.Price)
                burgerToUpdate.Price = newBurger.Price;
            if (burgerToUpdate.IsVegetarian != newBurger.IsVegetarian)
                burgerToUpdate.IsVegetarian = newBurger.IsVegetarian;
            if (burgerToUpdate.ContainAlergene != newBurger.ContainAlergene)
                burgerToUpdate.ContainAlergene = newBurger.ContainAlergene;

            burgerToUpdate.Ingredients = newBurger.Ingredients;

            await _dataContext.SaveChangesAsync();
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteBurger([FromRoute] Guid id)
    {
        try
        {
            var burgerToRemove = await _dataContext.Burgers
                .Include(b => b.Ingredients)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (burgerToRemove is null)
            {
                return Results.NotFound();
            }

            if (burgerToRemove.Ingredients != null && burgerToRemove.Ingredients.Count > 0)
            {
                _dataContext.Ingredients.RemoveRange(burgerToRemove.Ingredients);
            }

            _dataContext.Remove(burgerToRemove);
            await _dataContext.SaveChangesAsync();
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetBurgerById([FromRoute] Guid id)
    {
        try
        {
            var burgers = await _dataContext.Burgers
                .Include(b => b.Ingredients)
                .Select(b => new Burger
                {
                    Id = b.Id,
                    Name = b.Name,
                    Price = b.Price,
                    ContainAlergene = b.ContainAlergene,
                    Ingredients = b.Ingredients.Select(i => new Ingredient
                    {
                        Id = i.Id,
                        Name = i.Name,
                        KCal = i.KCal
                    }).ToList()
                })
                .FirstOrDefaultAsync(b => b.Id == id);

            return Results.Ok(burgers);
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }
}
