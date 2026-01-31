using BlazorApp1.Components.Database;
using BlazorApp1.Components.Database;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services;

public class OrderService
{
    private readonly SportShopDb db;
    public OrderService(SportShopDb db)
    {
        this.db = db;
    }
    
    public async Task<List<Order>> GetOrderAsync()
    {
        var orders = await db.Orders.ToListAsync();
        return orders;
        
    }

    public async Task<Order> CreateOrderAsync(string customerName, string customerSurname, string customerEmail,
        string customerPhoneNumber, string customerCity, string customerPostCode)
    {
        if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerSurname) ||
            string.IsNullOrEmpty(customerEmail) || string.IsNullOrEmpty(customerPhoneNumber) || string.IsNullOrEmpty(customerCity) || string.IsNullOrEmpty(customerPostCode))
        {
            throw new Exception("Required data/ Can't be  null");
        }

        var newOrder = new Order(customerName, customerSurname, customerEmail, customerPhoneNumber, customerCity,
            customerPostCode);
        await  db.Orders.AddAsync(newOrder);
        await db.SaveChangesAsync();
        return newOrder;
    }
    
    public async Task AddPositionAsync(int orderId,List<ProdData> items)
    {
        var order = await db.Orders.FindAsync(orderId);
        if (order == null)
        {
            throw new Exception("Order not found");
        }

        foreach (var v in items)
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.ProductID == v.ProductId);
            if (product == null) throw new Exception("Product not found");
            var newPosition = new OrderPosition(order.OrderId,v.ProductId,v.Qty,product.PriceNet);
            db.OrderPositions.Add(newPosition);

            product.Quantity -= v.Qty;
        }
        await db.SaveChangesAsync();
        
        var sumNet = await db.OrderPositions
            .Where(o => o.OrderId == order.OrderId)
            .SumAsync(o => o.Quantity* o.PriceNet);
        order.Amount = Math.Round(sumNet * 1.23m, 2);               
        await db.SaveChangesAsync();
    }


    public  async Task CancelOrderAsync(int orderId)
    {
        var order = await db.Orders.FindAsync(orderId);
        if (order == null) throw new Exception("Order not found");
        var positions = await db.OrderPositions
            .Where(op => op.OrderId == order.OrderId)
            .ToListAsync();

        if (order == null)
        {
            throw new Exception("Order not found");
        }
       
        foreach (var v in positions)
        {
            var product = await db.Products.FindAsync(v.ProductId);
            if (product == null) throw new Exception("Product not found");
            product.Quantity += v.Quantity;
        }
        db.OrderPositions.RemoveRange(positions);
        db.Orders.Remove(order);

        await db.SaveChangesAsync();
    }
}