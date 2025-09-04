using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public abstract class ProductDto
{
    protected ProductDto(string name, double price, int id)
    {
        this.Name = name;
        this.Price = price;
        this.Id = id;
    }
    
    public string Name { get;protected set; }
    public double Price { get; protected set; }
    public int Id { get;protected set; }
}
