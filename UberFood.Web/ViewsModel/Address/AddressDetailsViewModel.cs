using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace UberFood.Web.ViewsModel.Address;

public class AddressDetailsViewModel
{
    [HiddenInput]
    public Guid Id { get; set; }

    [DisplayName("Rue")]
    public string Street { get; set; } = string.Empty;

    [DisplayName("Ville")]
    public string City { get; set; } = string.Empty;

    [DisplayName("État")]
    public string State { get; set; } = string.Empty;

    [DisplayName("Code postal")]
    public string Zip { get; set; } = string.Empty;

    [DisplayName("Pays")]
    public string Country { get; set; } = string.Empty;
}
