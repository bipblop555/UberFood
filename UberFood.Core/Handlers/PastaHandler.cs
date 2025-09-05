using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Context;
using UberFood.Core.Models;

namespace UberFood.Core.Handlers;

public class PastaHandler
{
    
    public void AddPasta(PastaDto Pasta)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var pastaToAdd = new Entities.Pasta
                {

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

                    .Select(p => new PastaDto(p.Type,p.KCal,p.IsVegetarian, p.ContainAlergene, p.Name, p.Price, p.Id))
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

    public bool DeletePasta(string name)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var pastaToRemove = ctx.Burgers.FirstOrDefault(p => p.Name == name);
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
