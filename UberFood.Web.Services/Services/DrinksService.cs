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

    public async Task CreateDrinkAsync(DrinksDto drink)
    {
        var response = await this._httpClient.PostAsJsonAsync(_url, drink);
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task DeleteDrinkAsync(Guid id)
    {
        var response = await this._httpClient.DeleteAsync($"{_url}/{id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<DrinksDto> GetDrinkByIdAsync(Guid id)
    {
        var drink = await this._httpClient.GetFromJsonAsync<DrinksDto>($"{_url}/{id}");
        return drink ?? null;
    }

    public async Task<IEnumerable<DrinksDto>> GetDrinksAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<DrinksDto>>(_url);
        return response ?? Enumerable.Empty<DrinksDto>();
    }

    public async Task UpdateDrinkAsync(Guid id, DrinksDto drink)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{_url}/{id}", drink);
        _ = response.EnsureSuccessStatusCode();
    }
}
