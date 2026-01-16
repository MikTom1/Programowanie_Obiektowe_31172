namespace ConsoleApp2.Veh;

public class Car:Vehicle
{
    public Car(string model, string color, int year) : base(model, color, year)
    {
        
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Car Model: {Model}");
        Console.WriteLine($"Car Color: {Color}");
        Console.WriteLine($"Year: {Year}");
    }
}