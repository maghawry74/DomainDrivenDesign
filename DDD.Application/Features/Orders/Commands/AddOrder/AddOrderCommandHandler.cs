using DDD.Application.Contracts.Persistence.Repository;
using DDD.Application.Contracts.Services;
using DDD.Application.Exceptions;
using DDD.Domain.Models.Order.Aggregate;
using DDD.Domain.Repository;
using FluentValidation;
using MediatR;

namespace DDD.Application.Features.Orders.Commands.AddOrder;

public class AddOrderCommandHandler:IRequestHandler<AddOrderCommand,Guid>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitWork _unitWork;
    private readonly IValidator<AddOrderCommand> _validator;

    public AddOrderCommandHandler(IOrderRepository orderRepository,
        IUserRepository userRepository,
        IProductRepository productRepository,
        IUnitWork unitWork,
        IValidator<AddOrderCommand> validator)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
        _unitWork = unitWork;
        _validator = validator;
    }
    public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request,cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult.ToString()!);

        var newOrder = await Order.Create(
            request.Products.ToDictionary(p => p.Id, p => p.Quantity),
            request.UserId,
            _productRepository,
            _userRepository);
        await _orderRepository.Add(newOrder);
        await _unitWork.SaveChanges();

        return newOrder.OrderId.Value;
    }
}