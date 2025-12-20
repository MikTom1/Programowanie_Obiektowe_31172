namespace Lab3.Models;

public class Car : Vehicle
{
    public Car(int year, string model, string color) : base(year, model, color)
    {
      
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Samochód");
    }
    
}