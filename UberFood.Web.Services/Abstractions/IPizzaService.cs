using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Abstractions;

public interface IPizzaService
{
    Task<IEnumerable<PizzaDto>> GetPizzasAsync();
    Task<PizzaDto> GetPizzaByIdAsync(Guid id);
    Task CreatePizzaAsync(PizzaDto pizza);
    Task UpdatePizzaAsync(Guid id, PizzaDto pizza);
    Task DeletePizzaAsync(Guid id);
}
