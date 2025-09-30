using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Abstractions;

public interface IDrinksService
{
    Task<IEnumerable<DrinksDto>> GetDrinksAsync();
    Task<DrinksDto> GetDrinkByIdAsync(Guid id);
    Task CreateDrinkAsync(DrinksDto drink);
    Task UpdateDrinkAsync(Guid id, DrinksDto drink);
    Task DeleteDrinkAsync(Guid id);
}
