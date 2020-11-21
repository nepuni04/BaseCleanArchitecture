using System.Threading.Tasks;
using Api.Errors;
using Application.Common.Models;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries;
using Application.Products.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        public async Task<PaginatedList<ProductDto>> GetProducts([FromQuery] GetProductsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetProductById(int id)
        {
            return await Mediator.Send(new GetProductByIdQuery { Id = id });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<int> CreateProduct([FromBody] CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(new ApiResponse(400));
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }
    }
}
