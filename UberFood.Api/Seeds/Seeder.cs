using Microsoft.AspNetCore.Identity;
using UberFood.Api.Tools;
using UberFood.Core.Context;
using UberFood.Core.Entities;

namespace UberFood.Api.Seeds;

public class Seeder
{
    private readonly DataContext _dataContext;
    public Seeder(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task SeedDataAsync()
    {
        // --- Doughs ---
        var dough1 = new Dough { Name = "Classique" };
        await _dataContext.Doughs.AddAsync(dough1);

        var dough2 = new Dough { Name = "Fine" };
        await _dataContext.Doughs.AddAsync(dough2);

        var dough3 = new Dough { Name = "Épaisse" };
        await _dataContext.Doughs.AddAsync(dough3);

        // --- Pizzas ---
        var pizza1 = new Pizza { Name = "4 Fromages", Price = 9.99, Dough = dough1, ContainAlergene = true, IsVegetarian = true };
        await _dataContext.Pizzas.AddAsync(pizza1);

        var pizza2 = new Pizza { Name = "Chèvre Miel", Price = 10.00, Dough = dough2, ContainAlergene = true, IsVegetarian = true };
        await _dataContext.Pizzas.AddAsync(pizza2);

        var pizza3 = new Pizza { Name = "Reine", Price = 8.50, Dough = dough3, ContainAlergene = true, IsVegetarian = false };
        await _dataContext.Pizzas.AddAsync(pizza3);

        // --- Burgers ---
        var burger1 = new Burger { Name = "Big Mac", Price = 9.10, ContainAlergene = true, IsVegetarian = false };
        await _dataContext.Burgers.AddAsync(burger1);

        var burger2 = new Burger { Name = "Smash Burger", Price = 12.10, ContainAlergene = true, IsVegetarian = false };
        await _dataContext.Burgers.AddAsync(burger2);

        var burger3 = new Burger { Name = "Mac Chicken", Price = 9.10, ContainAlergene = true, IsVegetarian = false };
        await _dataContext.Burgers.AddAsync(burger3);

        // --- Drinks ---
        var drink1 = new Drink { Name = "Coca", Fizzy = true, KCal = 500, Price = 2.5 };
        await _dataContext.Drinks.AddAsync(drink1);

        var drink2 = new Drink { Name = "Eau", Fizzy = false, KCal = 0, Price = 1 };
        await _dataContext.Drinks.AddAsync(drink2);

        var drink3 = new Drink { Name = "Fanta", Fizzy = true, KCal = 350, Price = 2.4 };
        await _dataContext.Drinks.AddAsync(drink3);

        // --- Pastas ---
        var pasta1 = new Pasta { Name = "Pâtes Pesto", IsVegetarian = false, KCal = 750, Price = 11.00, ContainAlergene = true };
        await _dataContext.Pastas.AddAsync(pasta1);

        var pasta2 = new Pasta { Name = "Pâtes Carbonara", IsVegetarian = false, KCal = 800, Price = 10.00, ContainAlergene = true };
        await _dataContext.Pastas.AddAsync(pasta2);

        var pasta3 = new Pasta { Name = "Pâtes aux fromages", IsVegetarian = true, KCal = 750, Price = 9.00, ContainAlergene = true };
        await _dataContext.Pastas.AddAsync(pasta3);

        // --- Addresses ---
        var address1 = new Adress { City = "Orléans", Country = "France", State = "Loiret", Street = "1 rue bidon", Zip = "45000" };
        await _dataContext.Addresses.AddAsync(address1);

        var address2 = new Adress { City = "Paris", Country = "France", State = "Île-de-France", Street = "5 avenue du Général de Gaulle", Zip = "75000" };
        await _dataContext.Addresses.AddAsync(address2);

        // --- Users ---
        var user1 = new User { FirstName = "John", LastName = "Doe", Password = PasswordHash.HashPassword("123456789"),Mail = "johndoe@mail.com", Phone = "0633333333", Adresse = address1 };
        await _dataContext.Users.AddAsync(user1);

        var user2 = new User { FirstName = "Jane", LastName = "Dae", Password = PasswordHash.HashPassword("123456789"), Mail = "janedae@mail.com", Phone = "0644444444", Adresse = address2 };
        await _dataContext.Users.AddAsync(user2);

        // --- Ingredients (Burger & Pizza) ---
        var ingredients = new List<Ingredient>
    {
        // Burger 1
        new Ingredient { Name = "Tomate", Burger = burger1, KCal = 100 },
        new Ingredient { Name = "Steak Haché", Burger = burger1, KCal = 500 },
        new Ingredient { Name = "Cheddar", Burger = burger1, KCal = 300 },
        new Ingredient { Name = "Salade", Burger = burger1, KCal = 50 },
        new Ingredient { Name = "Sauce Bigmac", Burger = burger1, KCal = 300 },
        new Ingredient { Name = "Oignons", Burger = burger1, KCal = 50 },

        // Burger 2
        new Ingredient { Name = "Tomate", Burger = burger2, KCal = 100 },
        new Ingredient { Name = "Steak Haché", Burger = burger2, KCal = 500 },
        new Ingredient { Name = "Cheddar", Burger = burger2, KCal = 300 },
        new Ingredient { Name = "Salade", Burger = burger2, KCal = 50 },
        new Ingredient { Name = "Sauce Mayo", Burger = burger2, KCal = 300 },
        new Ingredient { Name = "Oignons", Burger = burger2, KCal = 50 },

        // Burger 3
        new Ingredient { Name = "Tomate", Burger = burger3, KCal = 100 },
        new Ingredient { Name = "Steak de Poulet", Burger = burger3, KCal = 500 },
        new Ingredient { Name = "Cheddar", Burger = burger3, KCal = 300 },
        new Ingredient { Name = "Salade", Burger = burger3, KCal = 50 },
        new Ingredient { Name = "Sauce Fumée", Burger = burger3, KCal = 300 },
        new Ingredient { Name = "Oignons", Burger = burger3, KCal = 50 },

        // Pizza 1
        new Ingredient { Name = "Sauce Tomate", Pizza = pizza1, KCal = 250 },
        new Ingredient { Name = "Fromage de chèvre", Pizza = pizza1, KCal = 300 },
        new Ingredient { Name = "Roquefort", Pizza = pizza1, KCal = 300 },

        // Pizza 2
        new Ingredient { Name = "Sauce Tomate", Pizza = pizza2, KCal = 250 },
        new Ingredient { Name = "Miel", Pizza = pizza2, KCal = 250 },

        // Pizza 3
        new Ingredient { Name = "Sauce Tomate", Pizza = pizza3, KCal = 250 },
        new Ingredient { Name = "Jambon", Pizza = pizza3, KCal = 300 },
        new Ingredient { Name = "Champignons", Pizza = pizza3, KCal = 100 },
        new Ingredient
        {
            Name = "Fromage de chèvre",
            Pizza = pizza3,
            KCal = 300
        }
    };
        await _dataContext.Ingredients.AddRangeAsync(ingredients);
        await _dataContext.SaveChangesAsync();
    }
}
