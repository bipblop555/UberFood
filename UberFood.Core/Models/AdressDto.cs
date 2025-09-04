using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFood.Core.Models;

public class AdressDto
{
    public AdressDto(string street,string city, string state,string zip,string country, int id) 
    {
        this.Street = street;
        this.City = city;
        this.State = state;
        this.Zip = zip;
        this.Country = country;
        this.Id = id;
    }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
    public int Id { get; set; }

}
