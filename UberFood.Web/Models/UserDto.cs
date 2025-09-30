namespace UberFood.Web.Models;

public class UserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty ;
    public string Phone { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public int AddressId { get; set; }
    public int Id { get; set; }

}
