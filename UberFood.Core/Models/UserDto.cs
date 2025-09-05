using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class UserDto
{
    public UserDto(string firstname, string lastname, string phone, string mail,int addressId, int id) 
    { 
        this.FirstName = firstname;
        this.LastName = lastname;
        this.Phone = phone;
        this.Mail = mail;
        this.AddressId = addressId;
        this.Id = id;
    }
    public UserDto(string firstname, string lastname, string phone, string mail, int addressId)
    {
        this.FirstName = firstname;
        this.LastName = lastname;
        this.Phone = phone;
        this.Mail = mail;
        this.AddressId = addressId;
    }

    public UserDto()
    {
        
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public int AddressId { get; set; }
    public int Id { get; set; }

}
