using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Products.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    public class GetProductsWithPaginationQuery : PaginationQuery, IRequest<PaginatedList<ProductDto>>
    {   
    }

    public class GetProductsWithPaginationQueryHandler : IRequestHandler<GetProductsWithPaginationQuery, PaginatedList<ProductDto>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsWithPaginationQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ProductDto>> Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Include(x => x.ProductType)
                .OrderBy(x => x.Name)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
