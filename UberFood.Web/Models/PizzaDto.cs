namespace UberFood.Web.Models;

public sealed class PizzaDto : FoodDto
{
    public int DoughId { get; set; }
    public DoughDto Dough { get; set; } = null!;
}
