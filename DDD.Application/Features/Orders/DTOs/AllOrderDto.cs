using DDD.Domain.Models.Order.Enums;

namespace DDD.Application.Features.Orders.DTOs;

public class AllOrderDto
{
    public Guid OrderId { get;  set; } 
    public decimal Price { get;  set; } 
    public OrderStatus OrderStatus { get;  set; }
}