namespace ConsoleApp2.Veh;

public class Bike: Vehicle
{
    public Bike(string model, string color, int year):base(model, color, year)
    {
        
    }
    
    public override void ShowInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Bike Model: {Model}");
        Console.WriteLine($"Bike Color: {Color}");
        Console.WriteLine($"Year: {Year}");
    }
}