using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UberFood.Web.ViewsModel.Ingredients;

namespace UberFood.Web.ViewsModel.Pizza;

public class PizzaCreateOrUpdateViewModel
{

    [DisplayName("Identifiant")]
    public Guid Id { get; set; }

    [Required]
    [DisplayName("Pâte")]
    public Guid DoughId { get; set; }

    [Required]
    [DisplayName("Nom")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Ingrédients")]
    public List<IngredientsViewModel> Ingredients { get; set; } = null!;

    [Required]
    [Range(0.01, 100)]
    [DisplayName("Prix (€)")]
    public double Price { get; set; }

    [DisplayName("Végétarienne")]
    public bool IsVegetarian { get; set; }

    [DisplayName("Contient des allergènes")]
    public bool ContainAlergene { get; set; }
    [DisplayName("Kilo Calories")]
    public bool KCal { get; set; }

    }
