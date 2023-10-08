using DDD.Domain.Models.Order.Entites;
using DDD.Domain.Models.Order.Enums;

namespace DDD.Application.Features.Orders.DTOs;

public class OrderDetailsDto
{
    public Guid OrderId { get;  set; } 
    public decimal Price { get;  set; } 
    public List<OrderProductDto> Items { set; get; }
    public OrderStatus OrderStatus { get;  set; }
    public OrderUserDto User { get;  set; }
}