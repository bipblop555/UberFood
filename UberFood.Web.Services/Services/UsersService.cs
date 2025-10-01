using System.Net.Http.Json;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Services.Dtos;

namespace UberFood.Web.Services.Services;

public class UsersService : IUsersService
{
    private readonly HttpClient _httpClient;
    private readonly string _url = "https://localhost:7014/api/user";

    public UsersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task CreateUserAsync(UserDto userDto)
    {
        var response = await _httpClient.PostAsJsonAsync(_url, userDto);
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var response = await this._httpClient.DeleteAsync($"{_url}/{id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
        var user = await this._httpClient.GetFromJsonAsync<UserDto>($"{_url}/{id}");
        return user ?? null;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>(_url);
        return response ?? Enumerable.Empty<UserDto>();

    }

    public async Task UpdateUserAsync(Guid id, UserDto user)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{_url}/{id}", user);
        _ = response.EnsureSuccessStatusCode();
    }
}
