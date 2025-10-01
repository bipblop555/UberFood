using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberFood.Core.Context;
using UberFood.Core.Entities;

namespace UberFood.Api.Controllers;

[Controller]
[Route("/api/[controller]")]
public sealed class IngredientsController : ControllerBase
{
    private readonly DataContext _dataContext;

    public IngredientsController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpPost]
    public async Task<IResult> AddIngredients([FromBody] Ingredient ingredient)
    {
        try
        {
            await _dataContext.AddAsync(ingredient);
            await _dataContext.SaveChangesAsync();

            return Results.Created();
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetIngredients()
    {
        try
        {
            var ingredients = await _dataContext.Ingredients
                .ToListAsync();

            return Results.Ok(ingredients);
        }
        catch (Exception e)
        {
            return Results.InternalServerError($"{e.Message}");
        }
    }
    [HttpGet("{id}")]
    public async Task<IResult> GetIngredient([FromRoute] Guid id)
    {
        try
        {
            var ingrToDetails = await _dataContext.Ingredients.FirstOrDefaultAsync(p => p.Id == id);
            if (ingrToDetails is null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(ingrToDetails);
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }
    [HttpPut("{id}")]
    public async Task<IResult> UpdateIngredient([FromRoute]Guid id, [FromBody] Ingredient ingredient)
    {
        try
        {
            var ingrToUpdate = await _dataContext.Ingredients.FirstOrDefaultAsync(p => p.Id == id);
            if (ingrToUpdate is null)
            {
                return Results.NotFound();
            }
            if(ingrToUpdate.Name != ingredient.Name)
            ingrToUpdate.Name = ingredient.Name;
            if(ingrToUpdate.KCal !=ingredient.KCal)
            ingrToUpdate.KCal = ingredient.KCal;
            
            await _dataContext.SaveChangesAsync();
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteIngredient([FromRoute] Guid id)
    {
        try
        {
            var ingrToRemove = await _dataContext.Ingredients.FirstOrDefaultAsync(p => p.Id == id);
            if (ingrToRemove is null)
            {
                return Results.NotFound();
            }
            _dataContext.Remove(ingrToRemove);
            await _dataContext.SaveChangesAsync();
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

}
