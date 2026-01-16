namespace ConsoleApp1.Models;

public class Order
{
    public int OrderId {get; set; }
    private List<OrderPosition> products;
    
    public Order()
    {}
}