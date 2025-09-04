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
    private DbContextOptions<DataContext> _options;
    public AdressHandler()
    {
        var builder = new DbContextOptionsBuilder<DataContext>();
        builder.UseSqlServer("Server=localhost;Database=Base;Trusted_Connection=True;");
        _options = builder.Options;
    }
    public void AddAdress(AdressDto adress)
    {
        try
        {
            using (var ctx = new DataContext(_options))
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
            using (var ctx = new DataContext(_options))
            {
                var adress = ctx.Adresses
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
            using (var ctx = new DataContext(_options))
            {
                var adressToRemove = ctx.Adresses.FirstOrDefault(p => p.Id == id);
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
