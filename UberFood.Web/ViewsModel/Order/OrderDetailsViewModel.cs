using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace UberFood.Web.ViewsModel.Order;

public class OrderDetailsViewModel
{
    [HiddenInput]
    public Guid Id { get; set; }
    [DisplayName("Date de commande")]
    public DateTime OrderDate { get; set; }
    [DisplayName("Date de Livraison")]
    public DateTime DeliveryDate { get; set; }
    [DisplayName("Status de la commande")]
    public int Status { get; set; }
    [DisplayName("Produits")]
    public string ProductName { get; set; } = string.Empty;
    [DisplayName("Prix")]
    public double Price { get; set; }
}
