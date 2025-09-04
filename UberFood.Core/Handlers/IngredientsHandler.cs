using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Context;
using UberFood.Core.Models;

namespace UberFood.Core.Handlers;

public sealed class IngredientsHandler
{
    private DbContextOptions<DataContext> _options;
    public IngredientsHandler()
    {
        var builder = new DbContextOptionsBuilder<DataContext>();
        builder.UseSqlServer("Server=localhost;Database=Base;Trusted_Connection=True;");
        _options = builder.Options;
    }
    public void AddIngredients(IngredientDto ingredient)
    {
        try
        {
            using (var ctx = new DataContext(_options))
            {
                var ingredientToAdd = new Entities.Ingredient
                {
                    Name = ingredient.Name,
                    KCal = ingredient.KCal,
                    PizzaId = ingredient.PizzaId,
                    BurgerId = ingredient.BurgerId,
                };

                ctx.Add(ingredientToAdd);
                ctx.SaveChanges();
            }
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public List<IngredientDto> GetIngredients()
    {
        try
        {
            using (var ctx = new DataContext(_options))
            {
                var ingredients = ctx.Ingredients
                    .Select(p => new IngredientDto(p.Name, p.KCal, p.Id, p.PizzaId, p.BurgerId))
                    .ToList();

                return ingredients;
            }
        } catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return [];
        }
    }

    public bool DeleteIngredient(string name)
    {
        try
        {
            using (var ctx = new DataContext(_options))
            {
                var ingrToRemove = ctx.Ingredients.FirstOrDefault(p => p.Name == name);
                if (ingrToRemove is not null)
                {
                    ctx.Remove(ingrToRemove);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        } catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}
