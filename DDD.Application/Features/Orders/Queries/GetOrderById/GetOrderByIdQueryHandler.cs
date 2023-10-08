using AutoMapper;
using DDD.Application.Exceptions;
using DDD.Application.Features.Orders.DTOs;
using DDD.Domain.Repository;
using MediatR;

namespace DDD.Application.Features.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler:IRequestHandler<GetOrderByIdQuery,OrderDetailsDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<OrderDetailsDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderDetails(request.Id)
                    ?? throw new NotFoundException($"Order With Id {request.Id} Not Found.");

        return _mapper.Map<OrderDetailsDto>(order);
    }
}