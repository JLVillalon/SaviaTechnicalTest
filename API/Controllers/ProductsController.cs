using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Queries.GetProductById;
using Application.Features.Products.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var idNewProduct = await _mediator.Send(command);
            return CreatedAtRoute("GetProductById", new { id = idNewProduct }, command);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ProductViewModel>> GetProductById(Guid id)
        {
            var query = new GetProductByIdQuery(id);
            var product = await _mediator.Send(query);

            if(product is null) return NotFound();
            return Ok(product);
        }
    }
}
