using System.Net.Http.Json;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly string _url = "https://localhost:7014/api/product";

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>(_url);
        return response ?? Enumerable.Empty<ProductDto>();
    }
}
