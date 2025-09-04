using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Context;
using UberFood.Core.Entities;
using UberFood.Core.Models;

namespace UberFood.Core.Handlers;

public sealed class PizzaHandler
{
    private DbContextOptions<DataContext> _options;
    public PizzaHandler()
    {
        var builder = new DbContextOptionsBuilder<DataContext>();
        builder.UseSqlServer("Server=localhost;Database=Base;Trusted_Connection=True;");
        _options = builder.Options;
    }
    public void AddPizza(PizzaDto pizza)
    {
        try
        {
            using (var ctx = new DataContext(_options))
            {
                var pizzaToAdd = new Entities.Pizza
                {
                    DoughId = pizza.DoughId,
                    IsVegetarian = pizza.IsVegetable,
                    Name = pizza.Name,
                    Price = pizza.Price,
                    ProductId = pizza.Id,
                    ContainAlergene = pizza.ContainAlergen
                };

                ctx.Add(pizzaToAdd);
                ctx.SaveChanges();
            }
        } catch(Exception e)
        {
           Console.WriteLine(e.Message);
        }
    }

    public List<PizzaDto> GetPizzas()
    {
        try
        {
            using (var ctx = new DataContext(_options))
            {
                var pizzas = ctx.Pizzas
                    .Include(p => p.Dough)
                    .Select(p => new PizzaDto(p.Dough.Name,p.DoughId, p.IsVegetarian, p.ContainAlergene, p.Name, p.Price, p.ProductId))
                    .ToList();

                return pizzas;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return [];
        }
    }

    public bool DeletePizza(string name)
    {
        try
        {
            using (var ctx = new DataContext(_options)) 
            {
                var pizzaToRemove = ctx.Pizzas.FirstOrDefault(p => p.Name == name);
                if (pizzaToRemove is not null)
                {
                    ctx.Remove(pizzaToRemove);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}
