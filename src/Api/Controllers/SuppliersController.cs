using System.Threading.Tasks;
using Application.Common.Models;
using Application.Suppliers.Queries;
using Application.Suppliers.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ApiController
    {
        [HttpGet]
        public async Task<PaginatedList<SupplierDto>> GetSuppliers([FromQuery] GetSuppliersWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<SupplierDto> GetSupplierById(int id)
        {
            return await Mediator.Send(new GetSupplierByIdQuery { Id = id });
        }
    }
}
