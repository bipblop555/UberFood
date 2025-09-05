using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public sealed class BurgerDto : FoodDto
{
    public BurgerDto(bool vegetarian, bool alergene, string name, double price, int id)
        : base(vegetarian, alergene, name, price, id)
    {
    }
    public BurgerDto(bool vegetarian, bool alergene, string name, double price)
        : base(vegetarian, alergene, name, price)
    {
    }
    
}
