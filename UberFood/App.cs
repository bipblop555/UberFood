using UberFood.Core;
using UberFood.Core.Context;

using Microsoft.EntityFrameworkCore;

using (var ctx = new DataContext())
{
    ctx.Database.EnsureCreated();
}

Console.WriteLine("Done");
