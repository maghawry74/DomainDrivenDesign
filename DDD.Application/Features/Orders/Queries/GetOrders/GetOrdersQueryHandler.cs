using AutoMapper;
using DDD.Application.Features.Orders.DTOs;
using DDD.Domain.Repository;
using MediatR;

namespace DDD.Application.Features.Orders.Queries.GetOrders;

public class GetOrdersQueryHandler:IRequestHandler<GetOrdersQuery,IEnumerable<AllOrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrdersQueryHandler(IOrderRepository orderRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<AllOrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAll();
        return _mapper.Map<IEnumerable<AllOrderDto>>(orders);
    }
}