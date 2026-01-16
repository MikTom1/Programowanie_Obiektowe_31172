namespace ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Models;
using ConsoleApp1;
using ConsoleApp1.Models;
public class Auth
{
    public string login{get;protected set;}
    public string password {get;protected set;}

    public Auth(string Login, string Password)
    {
        this.login = Login;
        this.password = Password;
    }

    public bool Login()
    {
        using var db = new DbShop();
        db.Database.EnsureCreated();
        var test=db.Users.Any(u => u.Login == this.login && u.Password == this.password);
        if (test == true) return true;
        else return false;
    }
}