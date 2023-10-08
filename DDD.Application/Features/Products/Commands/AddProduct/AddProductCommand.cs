using MediatR;

namespace DDD.Application.Features.Products.Commands.AddProduct;

public class AddProductCommand:IRequest<Guid>
{
    public string Name { get;  set; } 
    public decimal Price { get;  set; } 
    public int InventoryCount { get;  set; } 
    public string Image { get;  set; } 
}