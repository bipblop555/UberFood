using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services;

public class OrderProductDto
{
    public Guid OrderId { get; set; }
    public Guid ProductsId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public double ProductPrice { get; set; }
    public IEnumerable<ProductDto> Product { get; set; } = null!;
}
