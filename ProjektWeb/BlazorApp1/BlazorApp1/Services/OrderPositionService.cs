using BlazorApp1.Components.Database;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services;

public class OrderPositionService
{
    private readonly SportShopDb db;
    public OrderPositionService(SportShopDb _db)
    {
        db = _db;
    }
    public async Task<List<OrderPosition>> GetOrderAsync()
    {
        var orders = await db.OrderPositions.ToListAsync();
        return orders;
        
    }
}