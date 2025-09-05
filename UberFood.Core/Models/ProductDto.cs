using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class ProductDto
{
    public ProductDto(string name, double price, int id)
    {
        this.Name = name;
        this.Price = price;
        this.Id = id;
    }
    public ProductDto(string name, double price)
    {
        this.Name = name;
        this.Price = price;
    }

    public string Name { get; set; }
    public double Price { get; set; }
    public int Id { get; set; }
}
