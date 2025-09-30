using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberFood.Core.Context;
using UberFood.Core.Entities;

namespace UberFood.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AdressController : ControllerBase
{
    private readonly DataContext _dataContext;

    public AdressController(DataContext ctx)
    {
        _dataContext = ctx;
    }

    [HttpPost]
    public async Task<IResult> AddAdress([FromBody] Adress adress)
    {
        try
        {
            await _dataContext.AddAsync(adress);
            await _dataContext.SaveChangesAsync();
            return Results.Created();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return Results.InternalServerError();
        }
    }
    [HttpGet]
    public async Task<IResult> GetAdresses()
    {
        try
        {
            var adress = await _dataContext.Addresses
                .ToListAsync();

            return Results.Ok(adress);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return Results.NoContent();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteAdresses([FromRoute] Guid id)
    {
        try
        {
            var adressToRemove = await _dataContext.Addresses.FirstOrDefaultAsync(p => p.Id == id);
            if (adressToRemove is null)
            {
                Results.NoContent();
            } else
            {
                _dataContext?.Remove(adressToRemove);
                await _dataContext.SaveChangesAsync();
            }

            return Results.Ok(adressToRemove);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return Results.InternalServerError();
        }
    }
}
