using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Abstractions;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
}
