using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class FoodDto : ProductDto
{
    public FoodDto(bool vegetarian, bool alergene, string name, double price, int id)
            : base(name, price, id)
    {
        this.IsVegetable = vegetarian;
        this.ContainAlergen = alergene;
    }
    protected FoodDto(bool vegetarian, bool alergene, string name, double price)
            : base(name, price)
    {
        this.IsVegetable = vegetarian;
        this.ContainAlergen = alergene;
    }
    public bool IsVegetable { get; set; }
    public bool ContainAlergen { get; set; }

}
