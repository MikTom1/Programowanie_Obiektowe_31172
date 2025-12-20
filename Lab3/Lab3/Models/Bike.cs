namespace Lab3.Models;


public class Bike : Vehicle
{
    public Bike(int year, string model, string color) : base(year, model, color)
    {
      
    }
    public override void ShowInfo()
    {
        Console.WriteLine("Motor");
    }
}