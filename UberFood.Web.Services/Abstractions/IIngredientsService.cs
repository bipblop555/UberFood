
using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Abstractions;

public interface IIngredientsService
{
    Task<IEnumerable<IngredientDto>> GetIngredientsAsync();
    Task<IngredientDto> GetIngredientByIdAsync(Guid id);
    Task CreateIngredientAsync(IngredientDto ingredient);
    Task UpdateIngredientAsync(Guid id, IngredientDto ingredient);
    Task DeleteIngredientAsync(Guid id);
}
