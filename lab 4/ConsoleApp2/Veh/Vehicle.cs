namespace ConsoleApp2.Veh;

public abstract class Vehicle
{
  

    public string Model { get; protected set; }
 

    public int Id { get; protected set; }

    public int Year { get; protected set; }
    

    public string Color { get;  set; }

    protected Vehicle()
    {
    }

    protected Vehicle(string model, string color, int year)
    {
        if (year <= 1900)
        {
            throw new ArgumentException("Year must be greater than 1900");
        }
        Model = model;
        Color = color;
        Year = year;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Year: {Year}");
    }
}