using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using UberFood.Web.ViewsModel.Ingredients;

namespace UberFood.Web.ViewsModel.Burgers;

public class BurgerDetailsViewModel
{
    [HiddenInput]
    public Guid Id { get; set; }

    [DisplayName("Nom")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Prix")]
    public double Price { get; set; }

    [DisplayName("Contiens des allérgènes")]
    public bool ContainAlergene { get; set; }

    [DisplayName("Ingrédients")]
    public List<IngredientsViewModel> Ingredients { get; set; } = null!;
}
