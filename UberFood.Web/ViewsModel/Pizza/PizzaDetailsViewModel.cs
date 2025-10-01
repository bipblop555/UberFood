using System.ComponentModel;
using UberFood.Web.Services.Dtos;
using UberFood.Web.ViewsModel.Ingredients;

namespace UberFood.Web.ViewsModel.Pizza;

public class PizzaDetailsViewModel
{
    [DisplayName("Type de pâte")]
    public DoughDto Dough { get; set; } = null!;
    [DisplayName("Type de pâte")]
    public string DoughName { get; set; } = null;

    [DisplayName("Ingrédients")]
    public List<IngredientsViewModel> Ingredients { get; set; } = null!;

    // Hérités de ProductDto via FoodDto
    [DisplayName("Nom")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Prix (€)")]
    public double Price { get; set; }

    [DisplayName("Identifiant produit")]
    public Guid Id { get; set; }

    [DisplayName("Végétarienne")]
    public bool IsVegetarian { get; set; }

    [DisplayName("Contient des allergènes")]
    public bool ContainAlergene { get; set; }
}
