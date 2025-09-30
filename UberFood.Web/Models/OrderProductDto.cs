namespace UberFood.Web.Models;

public class OrderProductDto
{
    public int OrderId { get; set; }
    public int ProductsId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public double Price { get; set; }

    public ProductDto Product { get; set; } = null!;
}
