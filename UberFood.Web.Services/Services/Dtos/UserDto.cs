namespace UberFood.Web.Services.Services.Dtos;

public class UserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty ;
    public string Phone { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public AdressDto Adresse { get; set; } = null!;
    public Guid AdresseId { get; set; }
    public Guid Id { get; set; }
    public string Password {  get; set; } = string.Empty;
}
