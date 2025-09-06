using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Context;
using UberFood.Core.Entities;
using UberFood.Core.Models;

namespace UberFood.Core.Handlers;

public class AdressHandler
{
    public void AddAdress(AdressDto adress)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var adressToAdd = new Entities.Adress
                {
                    Id = adress.Id,
                    Street = adress.Street,
                    City = adress.City,
                    State = adress.State,
                    Zip = adress.Zip,
                    Country = adress.Country,

                };

                ctx.Add(adressToAdd);
                ctx.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public List<AdressDto> GetAdresses()
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var adress = ctx.Addresses
                    .Select(p => new AdressDto(p.Street, p.City, p.State, p.Zip, p.Country, p.Id))
                    .ToList();

                return adress;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return [];
        }
    }
    public bool DeleteAdresses(int id)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var adressToRemove = ctx.Addresses.FirstOrDefault(p => p.Id == id);
                if (adressToRemove is not null)
                {
                    ctx.Remove(adressToRemove);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }


}
