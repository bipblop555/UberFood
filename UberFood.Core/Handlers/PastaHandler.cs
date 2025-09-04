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
    private DbContextOptions<DataContext> _options;
    public PastaHandler()
    {
        var builder = new DbContextOptionsBuilder<DataContext>();
        builder.UseSqlServer("Server=localhost;Database=Base;Trusted_Connection=True;");
        _options = builder.Options;
    }
    public void AddPasta(PastaDto Pasta)
    {
        try
        {
            using (var ctx = new DataContext(_options))
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
            using (var ctx = new DataContext(_options))
            {
                var pastas = ctx.Pastas

                    .Select(p => new PastaDto(p.Type,p.KCal,p.IsVegetarian, p.ContainAlergene, p.Name, p.Price, p.ProductId))
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
            using (var ctx = new DataContext(_options))
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
