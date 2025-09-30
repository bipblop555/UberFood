namespace UberFood.Web.Services.Dtos;
public class IngredientDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double KCal { get; set; }
    public int? PizzaId { get; set; }
    public int? BurgerId { get; set; }
}
