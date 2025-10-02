using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using UberFood.Web.Services;

namespace UberFood.Web.ViewsModel.Order;

public class OrderCreateOrUpdateViewModel
{
    [HiddenInput]
    public Guid Id { get; set; }

    [DisplayName("Utilisateur")]
    public Guid UserId { get; set; }
    public IEnumerable<SelectListItem> Users { get; set; } = new List<SelectListItem>();

    [DisplayName("Adresse")]
    public Guid AddressId { get; set; }
    public IEnumerable<SelectListItem> Adresse { get; set; } = new List<SelectListItem>();

    [DisplayName("Date de commande")]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [DisplayName("Date de Livraison")]
    public DateTime DeliveryDate { get; set; } = DateTime.UtcNow.AddMinutes(30);

    [DisplayName("Status de la commande")]
    public int Status { get; set; } = 1;

    [DisplayName("Produit")]
    public Guid ProductId { get; set; }
    public IEnumerable<SelectListItem> Products { get; set; } = new List<SelectListItem>();
}
