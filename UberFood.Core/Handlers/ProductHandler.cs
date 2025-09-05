using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Context;
using UberFood.Core.Models;

namespace UberFood.Core.Handlers;

public class ProductHandler
{
    public List<ProductDto> GetProducts()
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var products = ctx.Products.Select(p => new ProductDto(p.Name, p.Price, p.Id))
                    .ToList();

                return products;
            }

        } catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return [];
        }
    } 
}
