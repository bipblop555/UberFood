using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UberFood.Web.ViewsModel.Address;

namespace UberFood.Web.ViewsModel.Users;

public class UsersCreateOrUpdateViewModel
{
    [DisplayName("Prénom")]
    public string FirstName { get; set; } = string.Empty;

    [DisplayName("Nom")]
    public string LastName { get; set; } = string.Empty;

    [DisplayName("Numéro de téléphone")]
    [MaxLength(10)]
    public string Phone { get; set; } = string.Empty;

    [DisplayName("Adresse email")]
    [EmailAddress]
    public string Mail { get; set; } = string.Empty;

    [DisplayName("Mot de passe")]
    [PasswordPropertyText]
    public string? Password { get; set; }

    public AddressCreateOrUpdateViewModel Adresse { get; set; } = null!;
}
