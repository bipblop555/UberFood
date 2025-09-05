using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Entities;

namespace UberFood.Core.Models;

public class OrderProductDto
{
    public OrderProductDto(int orderId, int productId, string name, double price)
    {
        OrderId = orderId;
        ProductsId = productId;
        this.ProductName = name;
        this.Price = price;
    }

    public OrderProductDto(int orderId, int productId)
    {
        OrderId = orderId;
        ProductsId = productId;
    }

    public OrderProductDto(int orderId, ProductDto productDto)
    {
        OrderId = orderId;
        this.Product = productDto;
    }

    public int OrderId { get; set; }
    public int ProductsId { get; set; }

    public string ProductName { get; set; } 
    public double Price { get; set; }

    public ProductDto Product {get; set;}
}
