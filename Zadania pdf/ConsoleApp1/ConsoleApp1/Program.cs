// See https://aka.ms/new-console-template for more information

Product p1 = new Product(1, "Laptop",200);
Product p2 = new Product(1, "Telefon",300);
Product p3 = new Product(1, "Sluchawki",200);

Order order1 = new Order();
order1.AddItem(p1, 2);
order1.AddItem(p3, 3);
order1.AddItem(p2, 4);
Console.WriteLine("Order status: " + order1.Status);
Console.WriteLine("Gross order value: " + order1.SumGross());
Console.WriteLine("Net order value: " + order1.SumNet());
order1.ChangeStatus(StatusOrder.Oplacone);
Console.WriteLine("New order status: "+ order1.Status);

class Product
{
    private int id;
    private string name;
    private decimal priceNet;

    public decimal PriceNet
    {
        get
        {
            return priceNet;
        }
        set
        {
            if (value < 0)
                throw new ArgumentException("Price Net cannot be negative");
            priceNet = value;
        }
    }

    public decimal PriceGross()
    {
        return priceNet*1.23m;
    }

    public int Id
    {
        get => id;
      
    }

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty");
            name = value;
        }
    }

    public Product(int id, string name, decimal priceNet)
    {
        this.id = id;
        Name = name;
        PriceNet = priceNet;
    }
}

class OrderItem
{
    private Product product;
    private int quantity;

    public Product Product
    {
        get => product;
    }

    public int Quantity
    {
        get
        {
            return quantity;
        }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Quantity cannot be 0 or less");
            quantity = value;
        }
    }

   public OrderItem(Product product, int quantity)
    {
        this.product = product;
        Quantity = quantity;
    }

    public decimal NetValue()
    {
       return Product.PriceNet* Quantity;
    }

    public decimal GrossValue()
    {
        return Product.PriceGross() * Quantity;
    }
}

enum StatusOrder
{
    Nowe,
    Oplacone,
    Wyslane,
    Anulowane
}

class Order
{
    private List<OrderItem> items;
    private StatusOrder status;
    private DateTime createdAt;

    public List<OrderItem> Items
    {
        get => items;
    }
    public StatusOrder Status
    {
        get => status;
    }
    public DateTime CreatedAt
    {
        get => createdAt;
    }
    public Order()
    {
        items= new List<OrderItem>();
        status=StatusOrder.Nowe;
        createdAt=DateTime.Now;
    }

    public void AddItem(Product product, int quantity)
    {
        if (status==StatusOrder.Anulowane)
        {
            throw new InvalidOperationException("Cannot add item to cancelled order");
        }
        if (product==null) 
        {
            throw new ArgumentNullException(nameof(product));
        }
        items.Add(new OrderItem(product, quantity));
    }

    public decimal SumNet()
    {
        decimal sum = 0m;
        foreach (var item in items)
        {
            sum +=item.NetValue();
        }

        return sum;
    }

    public decimal SumGross()
    {
        decimal sum = 0m;
        foreach (var item in items)
        {
            sum += item.GrossValue();
        }

        return sum;
    }

    public void ChangeStatus(StatusOrder newStatus)
    {
        if (status == StatusOrder.Anulowane)
            throw new InvalidOperationException("Cannot change status to cancelled order");
        if (newStatus == StatusOrder.Oplacone && Items.Count == 0)
            throw new InvalidOperationException("Cannot change status to empty order");
        status = newStatus;
    }
}

