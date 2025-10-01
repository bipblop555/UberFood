using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Abstractions;

internal interface IBurgerService
{
    Task<IEnumerable<BurgerDto>> GetBurgersAsync();

}
