namespace UberFood.Web.Services.Dtos;

public sealed class PizzaDto : FoodDto
{
    public Guid DoughId { get; set; }
    public DoughDto Dough { get; set; } = null!;
    //public List<IngredientDto> Ingredients { get; set; } = null!;
}
