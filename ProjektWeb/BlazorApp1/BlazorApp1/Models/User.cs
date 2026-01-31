using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Models;

public class User
{
    public int UserId { get; protected set; }
    public string FirstName { get; protected internal set; }
    public string LastName { get; protected internal set; }
    public string Role { get; protected internal set; }
    
    public string Login { get; protected internal set; }
    public string Password { get; protected internal set; }

    public int Quantity { get; protected internal set; } = 0;


    public User(string firstName, string lastName, string role, string login, string password)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Role = role;
        this.Login = login;
        this.Password = password;
    }

    public User()
    {
        
    }

    
} 