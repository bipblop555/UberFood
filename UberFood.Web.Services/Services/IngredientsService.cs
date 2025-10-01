using System.Net.Http.Json;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Services;

public class IngredientsService : IIngredientsService
{
    private readonly HttpClient _httpClient;
    private readonly string _url = "https://localhost:7014/api/ingredients";
    public IngredientsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<IngredientDto>> GetIngredientsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<IngredientDto>>(_url);
        return response ?? Enumerable.Empty<IngredientDto>();
    }
    public async Task<IngredientDto> GetIngredientByIdAsync(Guid id)
    {
        var ingredient = await this._httpClient.GetFromJsonAsync<IngredientDto>($"{_url}/{id}");
        return ingredient ?? null;
    }
    public async Task CreateIngredientAsync(IngredientDto ingredient)
    {
        var response = await this._httpClient.PostAsJsonAsync(_url, ingredient);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task UpdateIngredientAsync(Guid id, IngredientDto ingredient)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{_url}/{id}", ingredient);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task DeleteIngredientAsync(Guid id)
    {
        var response = await this._httpClient.DeleteAsync($"{_url}/{id}");
        _ = response.EnsureSuccessStatusCode();
    }
}
