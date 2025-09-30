using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberFood.Core.Context;
using UberFood.Core.Entities;

namespace UberFood.Api.Controllers;

[Controller]
[Route("/api/[controller]")]
public class PastaController : ControllerBase
{
    private readonly DataContext _dataContext;

    public PastaController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpPost]
    public async Task<IResult> AddPasta([FromBody] Pasta pasta)
    {
        try
        {
            await _dataContext.AddAsync(pasta);
            await _dataContext.SaveChangesAsync();

            return Results.Created();
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetPastas()
    {
        try
        {
            var pastas = await _dataContext.Pastas.ToListAsync();

            return Results.Ok(pastas);
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdatePasta([FromRoute] Guid id, [FromBody] Pasta newPasta)
    {
        try
        {
            var pastaToUpdate = await _dataContext.Pastas.FirstOrDefaultAsync(p => p.Id == id);
            if (pastaToUpdate is null)
                return Results.NotFound(id);

            if (pastaToUpdate.Name != newPasta.Name)
                pastaToUpdate.Name = newPasta.Name;
            if (pastaToUpdate.Price != newPasta.Price)
                pastaToUpdate.Price = newPasta.Price;
            if (pastaToUpdate.IsVegetarian != newPasta.IsVegetarian)
                pastaToUpdate.IsVegetarian = newPasta.IsVegetarian;
            if (pastaToUpdate.ContainAlergene != newPasta.ContainAlergene)
                pastaToUpdate.ContainAlergene = newPasta.ContainAlergene;

            _dataContext.Update(pastaToUpdate);
            await _dataContext.SaveChangesAsync();

            return Results.Ok(id);
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IResult> DeletePasta([FromRoute] Guid id)
    {
        try
        {
            var pastaToRemove = await _dataContext.Pastas.FirstOrDefaultAsync(p => p.Id == id);
            if (pastaToRemove is null)
            {
                return Results.NotFound();
            }
            _dataContext.Remove(pastaToRemove);
            await _dataContext.SaveChangesAsync();
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.InternalServerError($"{e.Message}");
        }
    }
}
