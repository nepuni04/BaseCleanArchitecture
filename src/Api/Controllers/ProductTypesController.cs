using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products.Responses;
using Application.ProductTypes.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ProductTypesController : ApiController
    {
        [HttpGet]
        public async Task<IList<ProductTypeDto>> GetProducts()
        {
            return await Mediator.Send(new GetProductTypesQuery());
        }
    }
}
