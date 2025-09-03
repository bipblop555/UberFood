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
            modelBuilder.Entity<Product>().HasData(
                    new Product { Name = "4 Fromages", Price = 9.99, ProductId = 1 },
                    new Product { Name = "Chèvre Miel", Price = 10.00, ProductId = 2 },
                    new Product { Name = "Reine", Price = 8.50, ProductId = 3 },
                    new Product { Name = "Big Max", Price = 9.10, ProductId = 4 },
                    new Product { Name = "Smash Burger", Price = 12.10, ProductId = 5 },
                    new Product { Name = "Big Max", Price = 9.10, ProductId = 6 }
                );
        }
    }
}
