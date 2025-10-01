using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using UberFood.Web.Services.Dtos;
using UberFood.Web.ViewsModel.Ingredients;

namespace UberFood.Web.ViewsModel.Burgers;

public class BurgersIndexViewModel
{
    [HiddenInput]
    public Guid Id { get; set; }

    [DisplayName("Nom")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Prix")]
    public double Price { get; set; }

}
