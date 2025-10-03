using System.Net.Http.Json;
using UberFood.Web.Services.Abstractions;

namespace UberFood.Web.Services.Services;

public class OrdersService : IOrdersService
{
    private readonly HttpClient _httpClient;
    private readonly string _url = "https://localhost:7014/api/order";

    public OrdersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task CreateOrderAsync(OrdersDto order)
    {
        var response = await this._httpClient.PostAsJsonAsync(_url, order);
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task DeleteOrderAsync(Guid id)
    {
        var response = await this._httpClient.DeleteAsync($"{_url}/{id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<OrdersDto> GetOrderByIdAsync(Guid id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_url}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Erreur HTTP {(int)response.StatusCode} : {response.ReasonPhrase}");
                return null;
            }

            var order = await response.Content.ReadFromJsonAsync<OrdersDto>();
            return order ?? null;
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

    public async Task<IEnumerable<OrdersDto>> GetOrdersAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<OrdersDto>>(_url);
        return response ?? Enumerable.Empty<OrdersDto>();
    }

    public async Task UpdateOrderrAsync(Guid id, OrdersDto order)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{_url}/{id}", order);
        _ = response.EnsureSuccessStatusCode();
    }
}
