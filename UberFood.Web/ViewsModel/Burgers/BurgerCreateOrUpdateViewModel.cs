using System.ComponentModel;
using UberFood.Web.ViewsModel.Ingredients;

namespace UberFood.Web.ViewsModel.Burgers;

public class BurgerCreateOrUpdateViewModel
{
    [DisplayName("Nom")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Prix")]
    public double Price { get; set; }

    [DisplayName("Contient des allérgènes")]
    public bool ContainAlergene { get; set; }

    public List<IngredientsCreateViewModel> Ingredients { get; set; } = null!;
}
