using System.ComponentModel.DataAnnotations;

namespace UberFood.Web.ViewsModel.Pasta;

public enum PastaType
{
    [Display(Name = "Pâtes Standard")]
    Standard = 0,

    [Display(Name = "Pâtes Complètes")]
    Complete = 1,

    [Display(Name = "Pâtes Colorées")]
    Coloree = 2
}

