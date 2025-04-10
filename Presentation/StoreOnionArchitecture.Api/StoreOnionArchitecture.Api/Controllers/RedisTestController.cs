using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreOnionArchitecture.Application.Features.Brands.Commands.CreateBrand;
using StoreOnionArchitecture.Application.Features.Brands.Querries.GetAllBrannds;
using StoreOnionArchitecture.Application.Features.Products.Command.UpdateProduct;

namespace StoreOnionArchitecture.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RedisTestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RedisTestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrands(CreateBrandCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
         
        }

        [HttpPost]
        public async Task<IActionResult> GetAllBrands(GetAllBranndsRequest request)
        {
         var respone =   await _mediator.Send(request);
            return Ok(respone);

        }
    }
}
