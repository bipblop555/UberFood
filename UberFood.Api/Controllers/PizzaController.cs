using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberFood.Core.Context;
using UberFood.Core.Entities;

namespace UberFood.Api.Controllers;

[Controller]
[Route("/api/[controller]")]

public sealed class PizzaController : ControllerBase
{
    private readonly DataContext _dataContext;

    public PizzaController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpPost]
    public async Task<IResult> AddPizza([FromBody] Pizza pizza)
    {
        try
        {
            await _dataContext.AddAsync(pizza);

            await _dataContext.SaveChangesAsync();
            return Results.Created();
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetPizzas()
    {
        try
        {
            var pizzas = await _dataContext.Pizzas
                .Include(p => p.Dough)
                .ToListAsync();

            return Results.Ok(pizzas);
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdatePizza([FromRoute] Guid id, [FromBody] Pizza newPizza)
    {
        try
        {
            var pizzaToUpdate = await _dataContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
            if (pizzaToUpdate is null)
                return Results.NotFound();
            if (pizzaToUpdate.Name != newPizza.Name)
                pizzaToUpdate.Name = newPizza.Name;
            if (pizzaToUpdate.Price != newPizza.Price)
                pizzaToUpdate.Price = newPizza.Price;
            if (pizzaToUpdate.IsVegetarian != newPizza.IsVegetarian)
                pizzaToUpdate.IsVegetarian = newPizza.IsVegetarian;
            if (pizzaToUpdate.ContainAlergene != newPizza.ContainAlergene)
                pizzaToUpdate.ContainAlergene = newPizza.ContainAlergene;
            if (pizzaToUpdate.DoughId != newPizza.DoughId)
                pizzaToUpdate.DoughId = newPizza.DoughId;

            _dataContext.Update(pizzaToUpdate);
            await _dataContext.SaveChangesAsync();

            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IResult> DeletePizza([FromRoute] Guid id)
    {
        try
        {
            var pizzaToRemove = await _dataContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
            if (pizzaToRemove is null)
            {
                return Results.NotFound();
            }

            _dataContext.Remove(pizzaToRemove);
            await _dataContext.SaveChangesAsync();

            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }
}