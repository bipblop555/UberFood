using Microsoft.AspNetCore.Mvc;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UberFood.Web.ViewsModel.Pasta;


public class PastaViewModel
{
    [HiddenInput]
    public Guid Id { get; set; }
    [DisplayName("Nom")]
    [Required(ErrorMessage = "Le nom est requis.")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Type de pate")]
    
    public PastaType Type { get; set; }
    [DisplayName("Kilo Calories")]
    public double KCal { get; set; }
    [DisplayName("Prix")]
    public double Price { get; set; }
    [DisplayName("Vegetarien")]
    public bool IsVegetarian { get; set; }
    [DisplayName("Contient des allergènes")]
    public bool ContainAlergene { get; set; }
}
