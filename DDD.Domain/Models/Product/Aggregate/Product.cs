using DDD.Domain.Exceptions;
using DDD.Domain.Models.Product.ValueObjects;

namespace DDD.Domain.Models.Product.Aggregate;

public class Product
{
    public ProductId ProductId { get; private set; } = null!;
    public ProductName Name { get; private set; } = null!;
    public Price Price { get; private set; } = null!;
    public InventoryCount InventoryCount { get; private set; } = null!;
    public Image Image { get; private set; } = null!;

    private Product()
    {
        
    }
    
    private Product(string name, decimal price, int inventoryCount, string image)
    {
        ProductId = new ProductId();
        Name = new ProductName(name);
        Price = new Price(price);
        InventoryCount = new InventoryCount(inventoryCount);
        Image = new Image(image);
    }
    public static Product Create(string name, decimal price, int inventoryCount, string image)
    {
        return new Product(name, price, inventoryCount, image);
    }

    public void DecreaseProductInventoryCount(int count)
    {
        if (count > InventoryCount.Value)
            throw new NoSufficientProductCountException(ProductId.Value,InventoryCount.Value);
        InventoryCount = new InventoryCount(count);
    }

    public void Update(string name, decimal price, int inventoryCount, string image)
    {
        Name = new ProductName(name);
        Price = new Price(price);
        InventoryCount = new InventoryCount(inventoryCount);
        Image = new Image(image);
    }
}
