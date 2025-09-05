using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Context;
using UberFood.Core.Models;

namespace UberFood.Core.Handlers;

public sealed class DrinksHandler
{
    public void AddDrink(DrinkDto drink)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var drinkToAdd = new Entities.Drink
                {
                    Fizzy = drink.IsFizzy,
                    KCal = drink.KCal,
                    Name = drink.Name,
                    Price = drink.Price
                };

                ctx.Add(drinkToAdd);
                ctx.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    public List<DrinkDto> GetDrinks() 
    {
        try
        {
            using (var ctx = new DataContext()) 
            {
                var drinks = ctx.Drinks.Select(d => new DrinkDto(d.Fizzy, d.KCal, d.Name, d.Price, d.Id)).ToList();
                return drinks;
            }
        } catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return [];
        }
    }

    public bool DeleteDrink(string name)
    {
        try
        {
            using (var ctx = new DataContext()) 
            {
                var drinkToRemove = ctx.Drinks.FirstOrDefault(d => d.Name == name);
                if(drinkToRemove is not null)
                {
                    ctx.Remove(drinkToRemove);
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
