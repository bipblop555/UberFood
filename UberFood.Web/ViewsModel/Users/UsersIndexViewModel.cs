using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace UberFood.Web.ViewsModel.Users;

public class UsersIndexViewModel
{
    [DisplayName("Prénom")]
    public string FirstName { get; set; } = string.Empty;

    [DisplayName("Nom")]
    public string LastName { get; set; } = string.Empty;

    [DisplayName("Numéro de téléphone")]
    public string Phone { get; set; } = string.Empty;

    [DisplayName("Adresse email")]
    public string Mail { get; set; } = string.Empty;

    [HiddenInput]
    public Guid AdresseId { get; set; }

    [HiddenInput]
    public Guid Id { get; set; }
}
