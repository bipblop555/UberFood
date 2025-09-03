using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class FoodDto : ProductDto
{
    public bool IsVegetable { get; set; }
    public bool ContainAlergen { get; set; }
    public int Id { get; set; }
}
