using DDD.Application.Contracts.Services;
using DDD.Application.Exceptions;
using DDD.Domain.Models.Order.ValueObjects;
using DDD.Domain.Repository;
using FluentValidation;
using MediatR;

namespace DDD.Application.Features.Orders.Commands.CancelOrder;

public class CancelOrderCommandHandler:IRequestHandler<CancelOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitWork _unitWork;
    private readonly IValidator<CancelOrderCommand> _validator;

    public CancelOrderCommandHandler(IOrderRepository orderRepository,
        IUnitWork unitWork,
        IValidator<CancelOrderCommand> validator)
    {
        _orderRepository = orderRepository;
        _unitWork = unitWork;
        _validator = validator;
    }
    public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request,cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult.ToString()!);

        var order = await _orderRepository.GetByCondition(o => o.OrderId == new OrderId(request.Id))
                    ?? throw new NotFoundException($"Order With Id {request.Id} Not Found");
        
        order.CancelOrder();
        _orderRepository.Update(order);
        await _unitWork.SaveChanges();
    }
}