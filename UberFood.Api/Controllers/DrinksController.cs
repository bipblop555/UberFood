using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberFood.Core.Context;
using UberFood.Core.Entities;

namespace UberFood.Api.Controllers;

[Controller]
[Route("/api/[controller]")]

public sealed class DrinksController : ControllerBase
{
    private readonly DataContext _dataContext;
    public DrinksController(DataContext ctx)
    {
        _dataContext = ctx;
    }

    [HttpPost]
    public async Task<IResult> AddDrink([FromBody] Drink drink)
    {
        try
        {
            await _dataContext.AddAsync(drink);
            await _dataContext.SaveChangesAsync();

            return Results.Created();
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }

    }

    [HttpGet]
    public async Task<IResult> GetDrinks()
    {
        try
        {
            var drinks = await _dataContext.Drinks.ToListAsync();
            return Results.Ok(drinks);
        }
        catch (Exception e)
        {
            return Results.InternalServerError($"{e.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteDrink([FromRoute] Guid id)
    {
        try
        {
            var drinkToRemove = await _dataContext.Drinks.FirstOrDefaultAsync(d => d.Id == id);
            if (drinkToRemove is null)
            {
                return Results.NotFound();
            }
            _dataContext.Remove(drinkToRemove);
            await _dataContext.SaveChangesAsync();

            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.InternalServerError($"{e.Message}");
        }
    }
}
