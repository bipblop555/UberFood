using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public abstract class FoodDto : ProductDto
{
    protected FoodDto(bool vegetarian,bool alergene, string name, double price, int id )
            : base(name, price, id)
    {
        this.IsVegetable = vegetarian;
        this.ContainAlergen = alergene;
    }
    public bool IsVegetable { get; protected set; }
    public bool ContainAlergen { get; protected set; }

}
