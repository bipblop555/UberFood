using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Abstractions;

public interface IBurgersService
{
    Task<IEnumerable<BurgerDto>> GetBurgersAsync();
    Task<BurgerDto> GetBurgerByIdAsync(Guid id);
    Task CreateBurgerAsync(BurgerDto burger);
    Task UpdateBurgerAsync(Guid id, BurgerDto burger);
    Task DeleteBurgerAsync(Guid id);
}
