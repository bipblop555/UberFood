using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UberFood.Web.Services.Abstractions;
using UberFood.Web.Services.Services.Dtos;
using UberFood.Web.Tools;
using UberFood.Web.ViewsModel.Address;
using UberFood.Web.ViewsModel.Users;

namespace UberFood.Web.Controllers;

public class UsersController : Controller
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    // GET: UserController
    public async Task<ActionResult> Index()
    {
        var users = await _usersService.GetUsersAsync();
        return View(users.Select(u => new UsersIndexViewModel
        {
            Id = u.Id,
            AdresseId = u.AdresseId,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Mail = u.Mail,
            Phone = u.Phone,
        }));
    }

    // GET: UserController/Details/5
    public async Task<ActionResult> Details(Guid id)
    {
        var user = await this._usersService.GetUserByIdAsync(id);
        if(user is null)
        {
            return this.NotFound();
        }
        var userFound = new UsersDetailsViewModel()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Phone = user.Phone,
            Mail = user.Mail,
            Adresse = new AddressDetailsViewModel()
            {
                City = user.Adresse.City,
                Country = user.Adresse.Country,
                Id = user.Adresse.Id,
                State = user.Adresse.State,
                Street = user.Adresse.Street,
                Zip = user.Adresse.Zip,
            }
        };
        return View(userFound);
    }

    // GET: UserController/Create
    public ActionResult Create()
    {
        var userCreateViewModel = new UsersCreateOrUpdateViewModel();
        return View(userCreateViewModel);
    }

    // POST: UserController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("FirstName, LastName, Mail, Phone, Password, Adresse")] UsersCreateOrUpdateViewModel viewModel)
    {
        //if(!this.ModelState.IsValid)
        //    return View(viewModel);

        var hashedPwd = PasswordHash.HashPassword(viewModel.Password);
        try
        {
            var newUser = new UserDto()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Password = hashedPwd,
                Phone = viewModel.Phone,
                Mail = viewModel.Mail,
                Adresse = new AdressDto()
                {
                    City = viewModel.Adresse.City,
                    Country = viewModel.Adresse.Country,
                    State = viewModel.Adresse.State,
                    Street = viewModel.Adresse.Street,
                    Zip = viewModel.Adresse.Zip,
                }
            };
            await this._usersService.CreateUserAsync(newUser);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: UserController/Edit/5
    public async Task<ActionResult> Edit(Guid id)
    {
        var user = await this._usersService.GetUserByIdAsync(id);
        if(user == null)
        {
            return this.NotFound();
        }
        var uViewModel = new UsersCreateOrUpdateViewModel()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Phone = user.Phone,
            Mail = user.Mail,
            Adresse = new AddressCreateOrUpdateViewModel()
            {
                City = user.Adresse.City,
                Country = user.Adresse.Country,
                State = user.Adresse.State,
                Street = user.Adresse.Street,
                Zip = user.Adresse.Zip,
            }
        };
        return View(uViewModel);
    }

    // POST: UserController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Guid id, [Bind("FirstName, LastName, Mail, Phone, Password, Adresse")] UsersCreateOrUpdateViewModel viewModel)
    {
        try
        {
            var hashedPwd = PasswordHash.HashPassword(viewModel.Password);

            var updatedUser = new UserDto()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Password = hashedPwd,
                Phone = viewModel.Phone,
                Mail = viewModel.Mail,
                Adresse = new AdressDto()
                {
                    City = viewModel.Adresse.City,
                    Country = viewModel.Adresse.Country,
                    State = viewModel.Adresse.State,
                    Street = viewModel.Adresse.Street,
                    Zip = viewModel.Adresse.Zip,
                }
            };
            await this._usersService.UpdateUserAsync(id, updatedUser);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: UserController/Delete/5
    public async Task<ActionResult> Delete(Guid id)
    {
        var user = await this._usersService.GetUserByIdAsync(id);
        if(user is null)
        {
            return this.NotFound();
        }

        var userFound = new UsersDetailsViewModel()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Phone = user.Phone,
            Mail = user.Mail,
            Adresse = new AddressDetailsViewModel()
            {
                City = user.Adresse.City,
                Country = user.Adresse.Country,
                Id = user.Adresse.Id,
                State = user.Adresse.State,
                Street = user.Adresse.Street,
                Zip = user.Adresse.Zip,
            }
        };
        return View(userFound);
    }

    // POST: UserController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(Guid id)
    {
        try
        {
            await this._usersService.DeleteUserAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
