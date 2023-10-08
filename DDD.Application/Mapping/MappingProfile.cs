using System.Security.Cryptography;
using AutoMapper;
using DDD.Application.Features.Orders.DTOs;
using DDD.Application.Features.Products.DTOs;
using DDD.Application.Features.Products.Queries.GetProducts;
using DDD.Application.Features.Users.Commands.Register;
using DDD.Application.Features.Users.DOTs;
using DDD.Application.Features.Users.Queries.GetAllUsers;
using DDD.Domain.Models.Order.Aggregate;
using DDD.Domain.Models.Order.Entites;
using DDD.Domain.Models.Product.Aggregate;
using DDD.Domain.Models.User.Aggregate;

namespace DDD.Application.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserRegisterDto>()
            .ForPath(src => src.Email, des => des.MapFrom(u => u.Email.Value))
            .ForPath(src => src.Id, des => des.MapFrom(u => u.UserId.Value))
            .ForPath(src => src.Password, des => des.MapFrom(u => u.Password.Value))
            .ForPath(src => src.Name, des => des.MapFrom(u => u.Name.Value))
            .ReverseMap();

        CreateMap<User, UserDto>()
            .ForPath(src => src.Email, des => des.MapFrom(u => u.Email.Value))
            .ForPath(src => src.Id, des => des.MapFrom(u => u.UserId.Value))
            .ForPath(src => src.Password, des => des.MapFrom(u => u.Password.Value))
            .ForPath(src => src.Name, des => des.MapFrom(u => u.Name.Value))
            .ReverseMap();

        CreateMap<Product, ProductsQueryDto>()
            .ForPath(src => src.Id, des => des.MapFrom(p => p.ProductId.Value))
            .ForPath(src => src.InventoryCount, des => des.MapFrom(p => p.InventoryCount.Value))
            .ForPath(src => src.Price, des => des.MapFrom(p => p.Price.Value))
            .ForPath(src => src.Name, des => des.MapFrom(p => p.Name.Value))
            .ForPath(src => src.Image, des => des.MapFrom(p => p.Image.Value))
            .ReverseMap();
        
        CreateMap<User, OrderUserDto>()
            .ForPath(src => src.Email, des => des.MapFrom(u => u.Email.Value))
            .ForPath(src => src.Id, des => des.MapFrom(u => u.UserId.Value))
            .ForPath(src => src.Name, des => des.MapFrom(u => u.Name.Value))
            .ReverseMap();
        
        
        CreateMap<LineItem, OrderProductDto>()
            .ForPath(src => src.Id, des => des.MapFrom(p => p.ProductId.Value))
            .ForPath(src => src.Quantity, des => des.MapFrom(p => p.Count.Value))
            .ForPath(src => src.InventoryCount, des => des.MapFrom(p => p.Product.InventoryCount.Value))
            .ForPath(src => src.Price, des => des.MapFrom(p => p.Product.Price.Value))
            .ForPath(src => src.Name, des => des.MapFrom(p => p.Product.Name.Value))
            .ForPath(src => src.Image, des => des.MapFrom(p => p.Product.Image.Value))
            .ReverseMap();

        CreateMap<Order, OrderDetailsDto>()
            .ForPath(src => src.Price, des => des.MapFrom(o => o.Price.Value))
            .ForPath(src => src.OrderId, des => des.MapFrom(o => o.OrderId.Value))
            .ForPath(src => src.Items, des => des.MapFrom(o => o.LineItems))
            .ReverseMap();
        
        CreateMap<Order, AllOrderDto>()
            .ForPath(src => src.Price, des => des.MapFrom(o => o.Price.Value))
            .ForPath(src => src.OrderId, des => des.MapFrom(o => o.OrderId.Value))
            
            .ReverseMap();
    }
}