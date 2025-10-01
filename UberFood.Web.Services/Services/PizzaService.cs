using System.Net.Http.Json;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Services;

public class PizzaService : IPizzaService
{
    private readonly HttpClient _httpClient;
    private readonly string _url = "https://localhost:7014/api/pizza";
    public PizzaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreatePizzaAsync(PizzaDto pizza)
    {
        var response = await this._httpClient.PostAsJsonAsync(_url, pizza);
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task DeletePizzaAsync(Guid id)
    {
        var response = await this._httpClient.DeleteAsync($"{_url}/{id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<PizzaDto?> GetPizzaByIdAsync(Guid id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_url}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Erreur HTTP {(int)response.StatusCode} : {response.ReasonPhrase}");
                return null;
            }

            var pizza = await response.Content.ReadFromJsonAsync<PizzaDto>();
            return pizza;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Exception HTTP : {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception générale : {ex.Message}");
            return null;
        }
    }

    public async Task<IEnumerable<PizzaDto>> GetPizzasAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<PizzaDto>>(_url);
        return response ?? Enumerable.Empty<PizzaDto>();
    }

    public async Task UpdatePizzaAsync(Guid id, PizzaDto pizza)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{_url}/{id}", pizza);
        _ = response.EnsureSuccessStatusCode();
    }
}
