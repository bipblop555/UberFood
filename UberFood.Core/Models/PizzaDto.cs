using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UberFood.Core.Models;

public sealed class PizzaDto : FoodDto
{
    public PizzaDto(string doughName, int DoughId, bool vegetarian,bool alergene,string name, double price,int id)
        : base(vegetarian, alergene, name, price, id)
    {
        this.DoughName = doughName;
        this.DoughId = DoughId;
    }
    public int DoughId { get; set; }

    public string DoughName { get; set; }
}
