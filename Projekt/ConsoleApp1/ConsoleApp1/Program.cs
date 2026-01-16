// See https://aka.ms/new-console-template for more information
using ConsoleApp1.Models;
using ConsoleApp1;
using System;
using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Models;
User admin =new User("Adam","Bielski","INF","admin","admin");
DbShop user = new DbShop();
void LoginPanel()
{
    var auth = true;
    Console.Clear();
    do
    {
        Console.WriteLine("Login:");
        string username = Console.ReadLine();
        Console.WriteLine("Password:");
        var password = Console.ReadLine();
        Auth authorization = new Auth(username, password);
        var data = authorization.Login();
        if (data==true)
        {
            auth = false;
            Console.WriteLine("Welcome to SportShop!");
            Menu();
        }
       else {
            Console.WriteLine("Wrong username or password!");
            Console.ReadKey();
        }

    }
    while (auth);
}

void Menu()
{
    var set = true;
    do
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1.Users");
        Console.WriteLine("2.Products");
        Console.WriteLine("3.Orders");
        Console.WriteLine("4.Warehouse");
        Console.WriteLine("0.Logout");
        var option = Console.ReadKey().KeyChar;
        switch (option)
        {
            case '1':
                UsersMenu();
                break;
            case '2':
                ProductMenu();
                break;
            case '3':
                OrdersMenu();
                break;
            case '4':
                WarehouseMenu();
                break;
            case '0':
                set = false;
                Console.WriteLine("Bye");
                Console.ReadKey();
                LoginPanel();
                break;
            default:
                break;
        }
        
    } while (set);
}

void UsersMenu()
{
    var optionmenu = true;
    do
    {
        Console.WriteLine("1.Show Users");
        Console.WriteLine("2.Delete User");
        Console.WriteLine("3.Add User");
        Console.WriteLine("4.Back to Main Menu");
        var option = Console.ReadKey().KeyChar;
        switch (option)
        {
            case '1':
                ShowUsers();
                break;
            case '2':
                DeleteUser();
                break;
            case '3':
                AddUser();
                break;  
            case '4':
                optionmenu = false;
                break;
            default:
                Console.WriteLine("Wrong option!");
                break;
        }
    }
    while(optionmenu==true);
}

void ProductMenu()
{
    do
    {
        
    }
    while(true);
}

void OrdersMenu()
{
    do
    {
        
    }
    while(true);
}

void WarehouseMenu()
{
    
}

void ShowUsers()
{
    foreach (var v in user.Users)
    {   
        Console.WriteLine(v.UserId);
        Console.WriteLine(v.FirstName + " " + v.LastName);
        Console.WriteLine(v.Role);
    }
}

void AddUser()
{
    Console.WriteLine("Provide a username");
    var username = Console.ReadLine();
    Console.WriteLine("Provide a Role");
    var role = Console.ReadLine();
    Console.WriteLine("Provide a login");
    var login = Console.ReadLine();
    Console.WriteLine("Provide a password");
    var password = Console.ReadLine();
    User newuser= new  User(username, password, role, login, password);
    user.Users.Add(newuser);
    user.SaveChanges();
}

void DeleteUser()
{
    foreach (var v in user.Users)
    {   
        Console.WriteLine(v.UserId);
        Console.WriteLine(v.FirstName + " " + v.LastName);
        Console.WriteLine(v.Role);
    }
    Console.WriteLine("Provide a user ID, which you want to delete");
    int id = Convert.ToInt32(Console.ReadLine());
    var userdelate = user.Users.FirstOrDefault(u => u.UserId == id);
    if (userdelate != null)
    {
        user.Users.Remove(userdelate);
        user.SaveChanges();
        
    }
    else
    {
        Console.WriteLine("Do not find a user with ID: " + id);
        
    }
}

LoginPanel();
/*using var db = new DbShop();
db.Database.EnsureCreated();

var user = new User("Jan","Kowalski","Admin");
db.Users.Add(user);
db.SaveChanges();

Console.WriteLine($"User ID: {user.UserId}");

var fromDb = db.Users
    .OrderByDescending(x => x.UserId)
    .First();
Console.WriteLine($"User ID: {fromDb.UserId}");
Console.WriteLine(db.DbPath);
*/


