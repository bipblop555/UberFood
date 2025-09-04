using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class DrinkDto : ProductDto
{
    public DrinkDto(bool fizzy,double kcal,string name,double price, int id):base(name,price,id) 
    {
        this.IsFizzy = fizzy;
        this.KCal= kcal;
    }
    public bool IsFizzy { get; set; }
    public double KCal { get; set; }
}
