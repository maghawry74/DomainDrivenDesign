using DDD.Application.Features.Products.Commands.AddProduct;
using DDD.Application.Features.Products.Commands.RemoveProduct;
using DDD.Application.Features.Products.Commands.UpdateProduct;
using DDD.Application.Features.Products.Queries.GetProductById;
using DDD.Application.Features.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _mediator.Send(new GetProductsQuery()));
        }
        
        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery(id)));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductCommand command)
        {
            var productId=await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { Id = productId }, null);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductByIdCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _mediator.Send(new RemoveProductByIdCommand(id));
            return NoContent();
        }
    }
}
