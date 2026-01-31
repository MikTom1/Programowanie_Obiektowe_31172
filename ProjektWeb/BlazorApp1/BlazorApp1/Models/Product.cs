namespace BlazorApp1.Models;

public class Product
{
    public int ProductID { get; protected set; }
    public string ProductName { get; protected internal set; }
    public decimal PriceNet { get; protected internal set; }
    public string Category { get; protected internal set; }
    public int Quantity { get; protected internal set; } = 0;

    public Product(string Name, decimal PriceNet, string Category)
    {
        this.ProductName = Name;
        this.PriceNet = PriceNet;
        this.Category = Category;
    }

    public Product()
    {
        
    }
    
}