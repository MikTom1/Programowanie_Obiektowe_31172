namespace Lab3.Models;

public abstract class Vehicle : Object
{
    private int year;
    private string model;
    private string color;

    public string Model
    {
        get => model;
    }

    public int Year
    {
        get => year;
    }

    public string Color
    {
        get
        {
            return color;
        }

        set
        {
            color = value;
        }
    }

    public Vehicle(int year, string model, string color)
    {
        this.model = model;
        this.year = year;
        this.color = color;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Model pojazdu: {this.model}");
        Console.WriteLine($"Rok produkcji pojazdu: {this.year}");
        Console.WriteLine($"Kolor: {this.color}");
    }
}