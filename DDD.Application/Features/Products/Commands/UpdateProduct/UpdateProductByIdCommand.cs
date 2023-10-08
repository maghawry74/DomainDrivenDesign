using MediatR;

namespace DDD.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductByIdCommand:IRequest
{
    public Guid Id { get; set; }
    public string Name { get;  set; } 
    public decimal Price { get;  set; } 
    public int InventoryCount { get;  set; } 
    public string Image { get;  set; } 
}