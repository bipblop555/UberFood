namespace UberFood.Web.Models;

public class FoodDto : ProductDto
{
    public bool IsVegetarian { get; set; }
    public bool ContainAlergene { get; set; }

}
