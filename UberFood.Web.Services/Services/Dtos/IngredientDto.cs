namespace UberFood.Web.Services.Dtos;
public class IngredientDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double KCal { get; set; }
    public Guid? PizzaId { get; set; }
    public Guid? BurgerId { get; set; }
}
