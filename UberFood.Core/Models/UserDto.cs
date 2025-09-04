using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class UserDto
{
    public UserDto(string firstname, string lastname, string phone, string mail, int id) 
    { 
        this.FirstName = firstname;
        this.LastName = lastname;
        this.Phone = phone;
        this.Mail = mail;
        this.Id = id;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public int Id { get; set; }

}
