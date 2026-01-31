using BlazorApp1.Components.Database;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;
namespace BlazorApp1.Services;

public class ProductService
{
    private readonly SportShopDb db;
    public ProductService(SportShopDb _db)
    {
        this.db = _db;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var products = await db.Products.ToListAsync();
        return products;
        
    }

    public async Task<Product> AddProductAsync(string ProductName, decimal PriceNet, string Category)
    {
        
        if (string.IsNullOrEmpty(ProductName) || string.IsNullOrEmpty(Category))
        {
            throw new Exception("Product name and Category are required");
        }

        if (PriceNet <= 0) throw new Exception("Price must be greater than zero");
        
        if (await db.Products.AnyAsync(u => u.ProductName == ProductName))
        {   
            throw new InvalidOperationException("Product with the same name already exists");
          
        }
      
        var newProduct = new Product(ProductName, PriceNet, Category);
        await db.Products.AddAsync(newProduct);
        await db.SaveChangesAsync();
        return newProduct;
    }
    
    public async Task<bool> DeleteProductAsync(HashSet<int> selectedProductIds)
    {   
        var productDel =  db.Products.Where(u => selectedProductIds.Contains(u.ProductID));
        if (await productDel.AnyAsync(u=>u.Quantity > 0)) return false;
        else
        {
            db.Products.RemoveRange(productDel);
            await db.SaveChangesAsync();
            return true;
        }
        
    }
    

    public async Task<Product> ReturnProductIDAsync(int id)
    {
        var prod = await db.Products.FirstOrDefaultAsync(u => u.ProductID == id);
        if (prod == null) throw new Exception("Product not found");
        return prod;
    }
    
    public async Task UpdateQuantityAsync(List<ProdData> prodData)
    {   
        
        foreach (var v in prodData)
        {
            var product = await db.Products.FirstOrDefaultAsync(u => u.ProductID == v.ProductId);
            if (product != null)
            {
                product.Quantity += v.Qty;
            }
            else
            {
                throw new Exception("Product not found");
            }
            
        }
        await db.SaveChangesAsync();
    }

    public async Task EditQuantityAsync(List<ProdData> prodData)
    {
        foreach (var v in prodData)
        {
            var product = await db.Products.FirstOrDefaultAsync(u => u.ProductID == v.ProductId);
            if (product != null)
            {
                product.Quantity = v.Qty;
            }
            else
            {
                throw new Exception("Product not found");
            }
            
        }
        await db.SaveChangesAsync();
    }
}