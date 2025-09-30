namespace UberFood.Web.Models;

public class ProductDto
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Id { get; set; }

    public List<IngredientDto> Ingredients { get; set; } = null!;
}
