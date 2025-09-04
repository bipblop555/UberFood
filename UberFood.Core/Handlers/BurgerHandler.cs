using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Context;
using UberFood.Core.Models;

namespace UberFood.Core.Handlers;

public sealed class BurgerHandler
{
    private DbContextOptions<DataContext> _options;
    public BurgerHandler()
    {
        var builder = new DbContextOptionsBuilder<DataContext>();
        builder.UseSqlServer("Server=localhost;Database=Base;Trusted_Connection=True;");
        _options = builder.Options;
    }
    public void AddBurger(BurgerDto burger)
    {
        try
        {
            using (var ctx = new DataContext(_options))
            {
                var burgerToAdd = new Entities.Burger
                {
                    
                };

                ctx.Add(burgerToAdd);
                ctx.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public List<BurgerDto> GetBurgers()
    {
        try
        {
            using (var ctx = new DataContext(_options))
            {
                var burgers = ctx.Burgers
                    
                    .Select(p => new BurgerDto(p.IsVegetarian, p.ContainAlergene, p.Name, p.Price, p.ProductId))
                    .ToList();

                return burgers;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return [];
        }
    }

    public bool DeleteBurger(string name)
    {
        try
        {
            using (var ctx = new DataContext(_options))
            {
                var burgerToRemove = ctx.Burgers.FirstOrDefault(p => p.Name == name);
                if (burgerToRemove is not null)
                {
                    ctx.Remove(burgerToRemove);
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
