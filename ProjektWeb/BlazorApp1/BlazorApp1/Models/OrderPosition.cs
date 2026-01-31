    namespace BlazorApp1.Models;

public class OrderPosition
{
    public int OrderPositionId { get; protected set; }
    
    public int OrderId { get; protected set; }
    public int ProductId { get; protected set; }
    public int Quantity { get; protected set; }
    public decimal PriceNet { get; protected set; }
   
   
   
    public OrderPosition(int orderId,int productId, int quantity, decimal priceNet)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        PriceNet = priceNet;
    }
    public OrderPosition()
    {
        
    }

   
}