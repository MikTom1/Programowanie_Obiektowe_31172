namespace BlazorApp1.Components.Database;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Models;
public class SportShopDb:DbContext
{
    public SportShopDb(DbContextOptions<SportShopDb> options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; protected set; }
    public DbSet<Order> Orders { get; protected set; }
    public DbSet<Product> Products { get; protected set; }
    public DbSet<OrderPosition> OrderPositions { get; protected set; }
    
    }
