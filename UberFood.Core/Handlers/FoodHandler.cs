using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Context;
using UberFood.Core.Models;

namespace UberFood.Core.Handlers;

public class FoodHandler
{
    public List<FoodDto> GetFoodAllergene()
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var foods = ctx.Foods
                    .Where(f => f.ContainAlergene == true)
                    .Select(f => new FoodDto(f.IsVegetarian, f.ContainAlergene, f.Name, f.Price, f.Id))
                    .ToList();

                return foods;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return [];
        }
    }

    public void KcalOrder(int id)
    {
        using (var ctx = new DataContext())
        {

        }
    }
}
