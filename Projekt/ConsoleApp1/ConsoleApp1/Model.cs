namespace ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using System;
using ConsoleApp1.Models;
using System.Collections.Generic;

public class DbShop : DbContext
{
    public DbSet<User> Users { get; protected set; }
    public DbSet<Order> Orders { get;}
    public DbSet<Product> Products { get;}
    public DbSet<OrderPosition> OrderPositions { get;}
    
    public string DbPath { get; }

    public DbShop()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "SportShop.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

