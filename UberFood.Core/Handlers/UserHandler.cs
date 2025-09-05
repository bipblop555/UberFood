using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Context;
using UberFood.Core.Models;

namespace UberFood.Core.Handlers;

public sealed class UserHandler
{
    
    public void AddUser(UserDto user)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var userToAdd = new Entities.User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Mail = user.Mail,

                };

                ctx.Add(userToAdd);
                ctx.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public List<UserDto> GetUsers()
    {
        try
        {
            using (var ctx = new DataContext())
            {
                //TODO ajouter adressid
                var users = ctx.Users
                    .Include(p => p.Adresse)
                    .Select(p => new UserDto(p.FirstName, p.LastName, p.Phone, p.Mail, p.AdresseId,p.Id))
                    .ToList();

                return users;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return [];
        }
    }
    public bool DeleteUsers(int id)
    {
        try
        {
            using (var ctx = new DataContext())
            {
                var userToRemove = ctx.Users.FirstOrDefault(p => p.Id == id);
                if (userToRemove is not null)
                {
                    ctx.Remove(userToRemove);
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
