using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UberFood.Core.Entities;

namespace UberFood.Core.Models;

public sealed class PizzaDto : FoodDto
{
    public PizzaDto( int doughId, bool vegetarian,bool alergene,string name, double price,int id)
        : base(vegetarian, alergene, name, price, id)
    {
     
        this.DoughId = doughId;
        
    }
    public PizzaDto(int doughId, bool vegetarian, bool alergene, string name, double price)
        : base(vegetarian, alergene, name, price)
    {

        this.DoughId = doughId;

    }
    public int DoughId { get; set; }

    public DoughDto Dough {  get; set; }
}
