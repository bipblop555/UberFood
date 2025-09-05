using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;
public sealed class PastaDto : FoodDto
{
    public PastaDto(int type, double kcal, bool vegetarian, bool alergene, string name, double price, int id)
    : base(vegetarian, alergene, name, price, id)
    {
        this.Type = type;
        this.KCal = kcal;
    }
    public PastaDto(int type, double kcal, bool vegetarian, bool alergene, string name, double price)
       : base(vegetarian, alergene, name, price)
    {
        this.Type = type;
        this.KCal = kcal;
    }
    public int Type { get; set; }
    public double KCal { get; set; }


}

