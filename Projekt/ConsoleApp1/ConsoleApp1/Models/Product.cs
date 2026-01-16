namespace ConsoleApp1.Models;

public class Product
{
   
    public int ProductId { get; set; }
    public string Name { get; private set; }
    public decimal PriceNet { get; private set; }
    public string Category { get; private set; }

    // ID ? baza danych
    public Product(string Name, decimal PriceNet, string Category)
    {
        this.Name = Name;
        this.PriceNet = PriceNet;
        this.Category = Category;
    }

    public Product()
    {
        
    }
}