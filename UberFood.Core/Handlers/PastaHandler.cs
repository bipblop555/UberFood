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

public class PastaHandler
{

    public void AddPasta(PastaDto pasta)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var pastaToAdd = new Entities.Pasta
                {
                    Type = pasta.Type,
                    KCal = pasta.KCal,
                    IsVegetarian = pasta.IsVegetable,
                    Name = pasta.Name,
                    Price = pasta.Price,
                    Id = pasta.Id,
                    ContainAlergene = pasta.ContainAlergen
                };

                ctx.Add(pastaToAdd);
                ctx.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public List<PastaDto> GetPastas()
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var pastas = ctx.Pastas

                    .Select(p => new PastaDto(p.Type, p.KCal, p.IsVegetarian, p.ContainAlergene, p.Name, p.Price, p.Id))
                    .ToList();

                return pastas;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return [];
        }
    }
    public bool UpdatePasta(PastaDto newPasta)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var pastaToUpdate = ctx.Pastas.Find(newPasta.Id);
                {
                    pastaToUpdate.Name = newPasta.Name;
                    pastaToUpdate.Price = newPasta.Price;
                    pastaToUpdate.IsVegetarian = newPasta.IsVegetable;
                    pastaToUpdate.ContainAlergene = newPasta.ContainAlergen;
                    pastaToUpdate.Id = newPasta.Id;

                    ctx.Update(pastaToUpdate);
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
    public bool DeletePasta(int id)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var pastaToRemove = ctx.Pastas.FirstOrDefault(p => p.Id == id);
                if (pastaToRemove is not null)
                {
                    ctx.Remove(pastaToRemove);
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
