using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Suppliers.Queries;
using Application.Suppliers.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ApiController
    {
        [HttpGet]
        public async Task<PaginatedList<SupplierDto>> GetProducts([FromQuery] GetSuppliersWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<SupplierDto> GetProductById(int id)
        {
            return await Mediator.Send(new GetSupplierByIdQuery { Id = id });
        }
    }
}
