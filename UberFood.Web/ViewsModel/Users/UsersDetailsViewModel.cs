using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using UberFood.Web.Services.Services.Dtos;
using UberFood.Web.ViewsModel.Address;

namespace UberFood.Web.ViewsModel.Users;

public class UsersDetailsViewModel
{
    [HiddenInput]
    public Guid Id { get; set; }

    [DisplayName("Prénom")]
    public string FirstName { get; set; } = string.Empty;

    [DisplayName("Nom")]
    public string LastName { get; set; } = string.Empty;

    [DisplayName("Numéro de téléphone")]
    public string Phone { get; set; } = string.Empty;

    [DisplayName("Adresse email")]
    public string Mail { get; set; } = string.Empty;
    public AddressDetailsViewModel Adresse { get; set; } = null!;
}
