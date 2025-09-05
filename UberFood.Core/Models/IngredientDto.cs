using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class IngredientDto
{
    private int? pizzaId;
    private int? burgerId;

    public IngredientDto(string name, double kcal,int id, int pizzaId, int burgerId)
    {
        this.Name = name;
        this.KCal = kcal;
        this.Id = id;
        PizzaId = pizzaId;
        BurgerId = burgerId;
    }

    public IngredientDto(string name, double kCal, int id, int? pizzaId, int? burgerId)
    {
        Name = name;
        KCal = kCal;
        Id = id;
        this.pizzaId = pizzaId;
        this.burgerId = burgerId;
    }

    public string Name { get; set; }
    public double KCal { get; set; }
    public int Id { get; set; }

    public int PizzaId { get; set; }
    public int BurgerId { get; set; }

}
