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
    public PizzaDto( DoughDto dough, bool vegetarian,bool alergene,string name, double price,int id)
        : base(vegetarian, alergene, name, price, id)
    {
     
        this.Dough = dough;
        
    }
    public PizzaDto(int doughId, string doughName, bool vegetarian, bool alergene, string name, double price, int id)
        : base(vegetarian, alergene, name, price, id)
    {

        this.Dough.Id = doughId;
        this.Dough.Name = doughName;

    }


    public DoughDto Dough {  get; set; }
}
