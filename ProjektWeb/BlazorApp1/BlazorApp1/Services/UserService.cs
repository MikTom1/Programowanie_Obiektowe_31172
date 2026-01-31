using BlazorApp1.Components.Database;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;
namespace BlazorApp1.Services;

public class UserService
{
    private readonly SportShopDb db;
    public UserService(SportShopDb _db)
    {
        this.db = _db;
    }
    public async Task<List<User>> GetUsersAsync()
    {
        var users = await db.Users.ToListAsync();
        return users;
        
    } 
    public async Task<User> AddUserAsync(string firstName, string lastName, string role, string login, string password)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(role))
        {
            throw new ArgumentNullException(nameof(firstName), $"{nameof(firstName)} or {nameof(lastName)} cannot be null");
        }

        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentNullException(nameof(login), $"{nameof(login)} or {nameof(password)} cannot be null");
        }
        if (await db.Users.AnyAsync(u => u.Login == login))
        {
            throw new InvalidOperationException("User with the same login already exists");
        }
        var newUser = new User(firstName, lastName, role, login, password);
        db.Users.Add(newUser);
        await db.SaveChangesAsync();
        return newUser;
    }

    public async Task DeleteUserAsync(HashSet<int> selectedIds)
    {
       
        var userDel= db.Users.Where(u => selectedIds.Contains(u.UserId));
        db.Users.RemoveRange(userDel);
        await db.SaveChangesAsync();
    }

    public async Task<User> ReturnUserIdAsync(int id)
    {
        var user = await db.Users.FirstOrDefaultAsync(u => u.UserId == id);
        if (user == null) throw new Exception("User not found");
        return user;
    }
    
}