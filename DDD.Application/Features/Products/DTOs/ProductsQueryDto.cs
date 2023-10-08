namespace DDD.Application.Features.Products.DTOs;

public class ProductsQueryDto
{
    public Guid Id { get;  set; } 
    public string Name { get;  set; } 
    public decimal Price { get;  set; } 
    public int InventoryCount { get;  set; } 
    public string Image { get;  set; } 
}