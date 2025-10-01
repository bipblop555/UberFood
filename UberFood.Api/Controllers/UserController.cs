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

    [HttpGet("{id}")]
    public async Task<IResult> GetUserById([FromRoute] Guid id)
    {
        try
        {
            var user = await _dataContext.Users
                .Include(u => u.Adresse)
                .FirstOrDefaultAsync(u => u.Id == id);

            if(user is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(user);
        } catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateUserById([FromRoute] Guid id,  [FromBody] User user)
    {
        try
        {
            var userToUpdate = await _dataContext.Users
                .Include(u => u.Adresse)
                .FirstOrDefaultAsync(u => u.Id == id);
            if(userToUpdate is null)
            {
                return Results.NotFound();
            }
            if(userToUpdate.FirstName != user.FirstName)
                userToUpdate.FirstName = user.FirstName;
            if(userToUpdate.LastName != user.LastName)
                userToUpdate.LastName = user.LastName;
            if(userToUpdate.Mail != user.Mail)
                userToUpdate.Mail = user.Mail;
            if(userToUpdate.Phone != user.Phone)
                userToUpdate.Phone = user.Phone;

            if (user.Adresse is not null)
            {
                userToUpdate.Adresse.Street = user.Adresse.Street;
                userToUpdate.Adresse.City = user.Adresse.City;
                userToUpdate.Adresse.State = user.Adresse.State;
                userToUpdate.Adresse.Zip = user.Adresse.Zip;
                userToUpdate.Adresse.Country = user.Adresse.Country;
            }

            await _dataContext.SaveChangesAsync();
            return Results.Ok(userToUpdate);
        } catch (Exception e)
        {
            return Results.InternalServerError(e.Message);
        }
    }
}
