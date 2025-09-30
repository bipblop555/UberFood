using System.ComponentModel;

namespace UberFood.Web.ViewsModel.Drinks;

public class DrinksCreateOrUpdateViewModel
{
    [DisplayName("Pétillant")]
    public bool Fizzy { get; set; }
    [DisplayName("Kilo Calories")]
    public double KCal { get; set; }
    [DisplayName("Nom")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Prix")]
    public double Price { get; set; }
}
