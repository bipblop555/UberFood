using System.Net.Http.Json;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Services;

public class BurgersService : IBurgersService
{
    private readonly HttpClient _httpClient;
    private readonly string _url = "https://localhost:7014/api/burger";

    public BurgersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task CreateBurgerAsync(BurgerDto burger)
    {
        var response = await this._httpClient.PostAsJsonAsync(_url, burger);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteBurgerAsync(Guid id)
    {
        var response = await this._httpClient.DeleteAsync($"{_url}/{id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<BurgerDto> GetBurgerByIdAsync(Guid id)
    {
        var burger = await this._httpClient.GetFromJsonAsync<BurgerDto>($"{_url}/{id}");
        return burger ?? null;
    }

    public async Task<IEnumerable<BurgerDto>> GetBurgersAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<BurgerDto>>(_url);
        return response ?? Enumerable.Empty<BurgerDto>();
    }

    public async Task UpdateBurgerAsync(Guid id, BurgerDto burger)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{_url}/{id}", burger);
        _ = response.EnsureSuccessStatusCode();
    }
}
