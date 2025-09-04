using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UberFood.Core.Models;

public sealed class PizzaDto : FoodDto
{
    public PizzaDto(int doughid, bool vegetarian,bool alergene,string name, double price,int id)
        : base(vegetarian, alergene, name, price, id)
    { 
        this.DoughId = doughid;
    }
    public int DoughId { get; set; }
}
