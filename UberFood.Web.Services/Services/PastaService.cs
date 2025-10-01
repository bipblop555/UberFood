using System.Net.Http.Json;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Services;

public class PastaService : IPastaService
{
    private readonly HttpClient _httpClient;
    private readonly string _url = "https://localhost:7014/api/pasta";
    public PastaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<PastaDto>> GetPastasAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<PastaDto>>(_url);
        return response ?? Enumerable.Empty<PastaDto>();
    }
    public async Task<PastaDto> GetPastaByIdAsync(Guid id)
    {
        var pasta = await this._httpClient.GetFromJsonAsync<PastaDto>($"{_url}/{id}");
        return pasta ?? null;
    }
    public async Task CreatePastaAsync(PastaDto pasta)
    {
        var response = await this._httpClient.PostAsJsonAsync(_url, pasta);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task UpdatePastaAsync(Guid id, PastaDto pasta)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{_url}/{id}", pasta);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task DeletePastaAsync(Guid id)
    {
        var response = await this._httpClient.DeleteAsync($"{_url}/{id}");
        _ = response.EnsureSuccessStatusCode();
    }

  
}
