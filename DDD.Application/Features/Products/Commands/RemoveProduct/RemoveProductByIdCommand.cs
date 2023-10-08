using MediatR;

namespace DDD.Application.Features.Products.Commands.RemoveProduct;

public record RemoveProductByIdCommand(Guid Id) : IRequest;
