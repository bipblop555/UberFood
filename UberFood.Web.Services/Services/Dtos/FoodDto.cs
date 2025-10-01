namespace UberFood.Web.Services.Dtos;

public class FoodDto : ProductDto
{
    public bool IsVegetarian { get; set; }
    public bool ContainAlergene { get; set; }
}
