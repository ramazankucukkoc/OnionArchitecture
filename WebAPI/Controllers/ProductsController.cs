using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
        {
            CreateProductDto result = await Mediator.Send(createProductCommand);
            return Created("", result);
        }

    }
}
