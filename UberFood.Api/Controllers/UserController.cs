using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberFood.Core.Context;
using UberFood.Core.Entities;

namespace UberFood.Api.Controllers;

[Controller]
[Route("/api/[controller]")]

public sealed class UserController : ControllerBase
{
    private readonly DataContext _dataContext;

    public UserController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    [HttpPost]
    public async Task<IResult> AddUser([FromBody] User user)
    {
        try
        {
            await _dataContext.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return Results.Created();
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetUsers()
    {
        try
        {
            //TODO ajouter adressid
            var users = await _dataContext.Users
                .Include(p => p.Adresse)
                .ToListAsync();

            return Results.Ok(users);
        }
        catch (Exception e)
        {
            return Results.InternalServerError($"{e.Message}");
        }
    }
    [HttpDelete("{id}")]
    public async Task<IResult> DeleteUsers([FromRoute] Guid id)
    {
        try
        {
            var userToRemove = await _dataContext.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (userToRemove is null)
            {
                return Results.NotFound();
            }

            _dataContext.Remove(userToRemove);
            await _dataContext.SaveChangesAsync();

            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

    [HttpGet("/default-user")]
    public async Task<IResult> GetDefaultUser()
    {
        try
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync();

            return Results.Ok(user);
        }
        catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }
}
