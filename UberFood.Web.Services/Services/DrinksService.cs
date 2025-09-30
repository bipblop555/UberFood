using System.Net.Http.Json;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Services;

public class DrinksService : IDrinksService
{
    private readonly HttpClient _httpClient;
    private readonly string _url = "https://localhost:7014/api/drinks";
    public DrinksService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<DrinksDto>> GetDrinksAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<DrinksDto>>(_url);
        return response ?? Enumerable.Empty<DrinksDto>();
    }
}
