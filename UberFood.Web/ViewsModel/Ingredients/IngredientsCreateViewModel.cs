using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace UberFood.Web.ViewsModel.Ingredients;

public class IngredientsCreateViewModel
{
    [DisplayName("Nom")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Kilo Calories")]
    public double KCal { get; set; }

    public Guid? Id { get; set; }

}
