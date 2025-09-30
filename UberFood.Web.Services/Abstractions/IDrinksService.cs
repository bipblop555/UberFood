using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Abstractions;

public interface IDrinksService
{
    Task<IEnumerable<DrinksDto>> GetDrinksAsync();
}
