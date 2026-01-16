namespace ConsoleApp1.Models;
public class User
{
    public int UserId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Role { get; private set; }
    
    public string Login { get; private set; }
    public string Password { get; private set; }
    
    public User(string FirstName, string LastName, string Role,  string Login, string Password)
    {
      
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Role = Role;
        this.Login = Login;
        this.Password = Password;
    }

    public User()
    {
        
    }
    
    
}