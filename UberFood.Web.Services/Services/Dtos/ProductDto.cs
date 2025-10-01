namespace UberFood.Web.Services.Dtos;

public class ProductDto
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public Guid Id { get; set; }

    public IEnumerable<IngredientDto> Ingredients { get; set; } = null!;
}
