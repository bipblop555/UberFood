using Microsoft.EntityFrameworkCore;
using UberFood.Core.Entities;

namespace UberFood.Core.Context;

public class DataContext : DbContext
{
    //public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<Food> Foods => Set<Food>();
    public DbSet<Drink> Drinks => Set<Drink>();
    public DbSet<Pasta> Pastas => Set<Pasta>();
    public DbSet<Burger> Burgers => Set<Burger>();
    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<Dough> Doughs => Set<Dough>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<Adress> Addresses => Set<Adress>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();
    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=EatDomicile;TrustServerCertificate=True;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().UseTptMappingStrategy();

        modelBuilder.Entity<Ingredient>()
            .HasOne(i => i.Burger)
            .WithMany(b => b.Ingredients)
            .HasForeignKey(i => i.BurgerId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Ingredient>()
            .HasOne(i => i.Pizza)
            .WithMany(p => p.Ingredients)
            .HasForeignKey(i => i.PizzaId)
            .OnDelete(DeleteBehavior.NoAction);
    }


}