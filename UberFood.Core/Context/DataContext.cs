using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFood.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace UberFood.Core.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Food> Foods => this.Set<Food>();
        public DbSet<Drink> Drinks => this.Set<Drink>();
        public DbSet<Pasta> Pastas => this.Set<Pasta>();
        public DbSet<Burger> Burgers => this.Set<Burger>();
        public DbSet<Pizza> Pizzas => this.Set<Pizza>();
        public DbSet<Dough> Doughs => this.Set<Dough>();

        public DbSet<Product> Ingredients => this.Set<Product>();
        public DbSet<Adress> Adresses => this.Set<Adress>();
        public DbSet<Product> Products => this.Set<Product>();
        public DbSet<Order> Orders => this.Set<Order>();
        public DbSet<OrderProduct> OrderProducts => this.Set<OrderProduct>();
        public DbSet<User> Users => this.Set<User>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost;Database=EatDomicile;TrustServerCertificate=True;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().UseTptMappingStrategy();
            modelBuilder.Entity<Pizza>().HasData(
                    new Pizza { Name = "4 Fromages", Price = 9.99, ProductId = 1, DoughId = 1 },
                    new Pizza { Name = "Chèvre Miel", Price = 10.00, ProductId = 2, DoughId = 2 },
                    new Pizza { Name = "Reine", Price = 8.50, ProductId = 3, DoughId = 3 });
            modelBuilder.Entity<Burger>().HasData(
                    new Burger { Name = "Big Mac", Price = 9.10, ProductId = 4 },
                    new Burger { Name = "Smash Burger", Price = 12.10, ProductId = 5 },
                    new Burger { Name = "Mac Chicken", Price = 9.10, ProductId = 6 });
            modelBuilder.Entity<Dough>().HasData(
                    new Dough { Id = 1, Name = "Classique" },
                    new Dough { Id = 2, Name = "Fine" },
                    new Dough { Id = 3, Name = "Épaisse" });
            modelBuilder.Entity<Drink>().HasData(
                    new Drink { Name = "Coca", Fizzy = true, KCal = 500, Price = 2.5, ProductId = 7 },
                    new Drink { Name = "Eau", Fizzy = false, KCal = 0, Price = 1, ProductId = 8 },
                    new Drink { Name = "Fanta", Fizzy = true, KCal = 350, Price = 2.4, ProductId = 9 });
            modelBuilder.Entity<Pasta>().HasData(
                    new Pasta { Name = "Pâtes Pesto", IsVegetarian = false, KCal = 750, Price = 11.00, ProductId = 10 },
                    new Pasta { Name = "Pâtes Carbonara", IsVegetarian = false, KCal = 800, Price = 10.00, ProductId = 11 },
                    new Pasta { Name = "Pâtes aux fromages", IsVegetarian = true, KCal = 750, Price = 9.00, ProductId = 12 });
            modelBuilder.Entity<User>().HasData(
                    new User { FirstName = "John", LastName = "Doe", Id = 1, Mail = "johndoe@mail.com", Phone = 0633333333, AdresseId = 1 },
                    new User { FirstName = "Jane", LastName = "Dae", Id = 2, Mail = "janedae@mail.com", Phone = 0644444444, AdresseId = 2 });
            modelBuilder.Entity<Adress>().HasData(
                    new Adress { City = "Orléans", Country = "France", Id = 1, State = "Loiret", Street = "1 rue bidon", Zip = "45000" },
                    new Adress { City = "Paris", Country = "France", Id = 2, State = "Ile de France", Street = "5 avenue du Général de Gaule", Zip = "75000" });
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Name = "Tomate", Id = 1, BurgerId = 1 },
                    new Ingredient { Name = "Tomate", Id = 2, BurgerId = 2 },
                    new Ingredient { Name = "Tomate", Id = 3, BurgerId = 3 },

                    new Ingredient { Name = "Steak Haché", Id = 4, BurgerId = 1 },
                    new Ingredient { Name = "Steak Haché", Id = 5, BurgerId = 2 },
                    new Ingredient { Name = "Steak de Poulet", Id = 6, BurgerId = 3 },

                    new Ingredient { Name = "Cheddar", Id = 7, BurgerId = 1 },
                    new Ingredient { Name = "Cheddar", Id = 8, BurgerId = 2 },
                    new Ingredient { Name = "Cheddar", Id = 9, BurgerId = 3 },

                    new Ingredient { Name = "Sauce Tomate", Id = 10, PizzaId = 1 },
                    new Ingredient { Name = "Sauce Tomate", Id = 11, PizzaId = 2 },
                    new Ingredient { Name = "Sauce Tomate", Id = 12, PizzaId = 3 },

                    new Ingredient { Name = "Jambon", Id = 13, PizzaId = 3 },
                    new Ingredient { Name = "Champignons", Id = 14, PizzaId = 3 },
                    new Ingredient { Name = "Fromage de chèvre", Id = 15, PizzaId = 3 },

                    new Ingredient { Name = "Fromage de chèvre", Id = 16, PizzaId = 1 },
                    new Ingredient { Name = "Roquefort", Id = 17, PizzaId = 1 },
                    new Ingredient { Name = "Sauce Tomate", Id = 18, PizzaId = 3 },

                    new Ingredient { Name = "Miel", Id = 19, PizzaId = 2 },
                    new Ingredient { Name = "Salade", Id = 20, BurgerId = 1 },
                    new Ingredient { Name = "Salade", Id = 21, BurgerId = 2 },
                    new Ingredient { Name = "Salade", Id = 22, BurgerId = 3 },

                    new Ingredient { Name = "Sauce Bigmac", Id = 23, BurgerId = 1 },
                    new Ingredient { Name = "Sauce Mayo", Id = 24, BurgerId = 2 },
                    new Ingredient { Name = "Sauce Fumée", Id = 25, BurgerId = 3 },

                    new Ingredient { Name = "Oignons", Id = 26, BurgerId = 1 },
                    new Ingredient { Name = "Oignons", Id = 27, BurgerId = 2 },
                    new Ingredient { Name = "Oignons", Id = 28, BurgerId = 3 },
                    );
        }
    }
}
