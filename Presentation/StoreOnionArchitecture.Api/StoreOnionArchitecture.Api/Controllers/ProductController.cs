using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreOnionArchitecture.Application.Features.Products.Command.DeleteProduct;
using StoreOnionArchitecture.Application.Features.Products.Command.UpdateProduct;
using StoreOnionArchitecture.Application.Features.Products.Querries.GetAllProducts;
using StoreOnionArchitecture.Domain.Common.CreateProduct;

namespace StoreOnionArchitecture.Api.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await _mediator.Send(request );

            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            await _mediator.Send(request );
            return Ok();
        }

        [HttpGet()]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> TestAdmin()
        {
            return Ok();
        }
        [HttpGet()]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> TestUser()
        {
            return Ok();
        }
    }
}
