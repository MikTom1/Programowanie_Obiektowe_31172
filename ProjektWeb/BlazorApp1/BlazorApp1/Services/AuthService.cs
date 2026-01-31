using BlazorApp1.Components.Database;

namespace BlazorApp1.Services;


public class AuthService
{
    
    private readonly SportShopDb db;

    public AuthService(SportShopDb _db)
    {
        this.db = _db;
    }




    public bool Login(string login, string password)
    {
     
        var test = db.Users.Any(u => u.Login == login && u.Password == password);
        
        
        return test;
    }

    
    
}   