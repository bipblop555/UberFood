using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class IngredientDto
{
    public IngredientDto(string name, double kcal,int id)
    {
        this.Name = name;
        this.KCal = kcal;
        this.Id = id;
        
    }
    public string Name { get; set; }
    public double KCal { get; set; }
    public int Id { get; set; }

}
