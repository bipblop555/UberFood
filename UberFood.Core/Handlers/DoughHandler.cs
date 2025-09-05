using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Context;
using UberFood.Core.Models;

namespace UberFood.Core.Handlers
{
    public sealed class DoughHandler
    {
        public void AddDough(DoughDto dough)
        {
            try
            {
                using (var ctx = new DataContext())
                {
                    var doughToAdd = new Entities.Dough
                    {
                        
                        Name = dough.Name,
                        
                        Id = dough.Id,
                        
                    };

                    ctx.Add(doughToAdd);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<DoughDto> GetDoughs()
        {
            try
            {
                using (var ctx = new DataContext())
                {
                    var doughs = ctx.Doughs

                        .Select(p => new DoughDto(p.Name, p.Id))
                        .ToList();
                        

                    return doughs;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return [];
            }
        }
        //public DoughDto GetDough(int id)
        //{
        //    try
        //    {
        //        using (var ctx = new DataContext())
        //        {
        //            var dough = ctx.Doughs

        //                .Select(p => new DoughDto(p.Name, p.Id))
        //                .Where(p => p.Id == id);


        //            return dough;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return null;
        //    }
        //}

        public bool DeleteDough(string name)
        {
            try
            {
                using (var ctx = new DataContext())
                {
                    var doughToRemove = ctx.Doughs.FirstOrDefault(p => p.Name == name);
                    if (doughToRemove is not null)
                    {
                        ctx.Remove(doughToRemove);
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
}
