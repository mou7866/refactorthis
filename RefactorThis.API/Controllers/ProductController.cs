using MediatR;
using Microsoft.AspNetCore.Mvc;
using RefactorThis.Domain.Aggregates.Product.Commands;
using RefactorThis.Domain.Aggregates.Product.Queries;
using RefactorThis.Domain.Product.Models;
using System;
using System.Threading.Tasks;

namespace RefactorThis.API.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IMediator Mediator { get; init; }

        public ProductController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery()));
        }

        [Route("name={name}")]
        [HttpGet]
        public async Task<IActionResult> SearchByName(string name)
        {
            return Ok(await Mediator.Send(new GetProductByNameQuery(name)));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> SearchById([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand createProductCommand)
        {
            return Ok(await Mediator.Send(createProductCommand));
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ProductModel product)
        {
            return Ok(await Mediator.Send(new UpdateProductCommand(id, product)));
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new DeleteProductCommand(id)));
        }

        [Route("{productId}/options")]
        [HttpGet]
        public async Task<IActionResult> GetOptions([FromRoute] Guid productId)
        {
            return Ok(await Mediator.Send(new GetProductOptionsByProductIdQuery(productId)));
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetOption(Guid productId, Guid id)
        {
            return Ok(await Mediator.Send(new GetProductOptionsByProductIdQuery(productId)));
        }

        [Route("{productId}/options")]
        [HttpPost]
        public async Task<IActionResult> CreateOption([FromRoute] Guid productId, [FromBody] ProductOptionModel option)
        {
            return Ok(await Mediator.Send(new CreateProductOptionCommand(productId, option)));
        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateOption([FromRoute] Guid productId, [FromRoute] Guid id, [FromBody] ProductOptionModel option)
        {
            return Ok(await Mediator.Send(new UpdateProductOptionCommand(productId, id, option)));
        }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOption([FromRoute] Guid productId, [FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new DeleteProductOptionCommand(productId, id)));
        }
    }
}
