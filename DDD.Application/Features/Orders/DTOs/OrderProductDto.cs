namespace DDD.Application.Features.Orders.DTOs;

public class OrderProductDto
{
    public Guid Id { get;  set; } 
    public string Name { get;  set; } 
    public decimal Price { get;  set; } 
    public int InventoryCount { get;  set; } 
    public string Image { get;  set; }
    public int  Quantity { get; set; }
}