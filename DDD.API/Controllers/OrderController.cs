using DDD.Application.Features.Orders.Commands.AddOrder;
using DDD.Application.Features.Orders.Commands.CancelOrder;
using DDD.Application.Features.Orders.Commands.ChangeOrderStatus;
using DDD.Application.Features.Orders.Queries.GetOrderById;
using DDD.Application.Features.Orders.Queries.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _mediator.Send(new GetOrdersQuery()));
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            return Ok(await _mediator.Send(new GetOrderByIdQuery(id)));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, null);
        }
        
        [HttpPatch]
        [Route("Status")]
        public async Task<IActionResult> UpdateOrder(ChangeOrderStatusCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        
        [HttpPatch]
        [Route("Cancel/{id:guid}")]
        public async Task<IActionResult> UpdateOrder(Guid id)
        {
            await _mediator.Send(new CancelOrderCommand(id));
            return NoContent();
        }
    }
}
