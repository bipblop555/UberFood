namespace UberFood.Core.Entities;

public class Pizza : Food
{
    public Guid DoughId { get; set; }
    public Dough Dough { get; set; } = null!;

    public List<Ingredient> Ingredients { get; set; } = null!;
}
