namespace BlazorApp1.Models;

public class Order
{
    public int OrderId { get; protected set; }
    public string CustomerName { get; protected set; }
    public string CustomerSurname { get; protected set; }
    public string CustomerEmail { get; protected set; }
    public string CustomerPhoneNumber { get; protected set; }
    public string CustomerCity { get; protected set; }
    public string CustomerPostCode { get; protected set; }
    public decimal Amount { get; protected internal set; }
    public DateTime OrderDate  { get; protected set; }
    
    private readonly List<OrderPosition> products;
    public ICollection<OrderPosition> Products => products;


    public Order(string customerName, string customerSurname, string customerEmail,
        string customerPhoneNumber, string customerCity, string customerPostCode)
    {
        products = new List<OrderPosition>();
        
        this.CustomerName = customerName;
        this.CustomerSurname = customerSurname;
        this.CustomerEmail = customerEmail;
        this.CustomerPhoneNumber = customerPhoneNumber;
        this.CustomerCity = customerCity;
        this.CustomerPostCode = customerPostCode;
        this.OrderDate = DateTime.UtcNow;
        
    }

    public Order()
    {
        
    }
    
}