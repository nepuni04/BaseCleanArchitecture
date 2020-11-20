using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Suppliers.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Suppliers.Queries
{
    public class GetSuppliersWithPaginationQuery : PaginationQuery, IRequest<PaginatedList<SupplierDto>>
    {
    }

    public class GetSuppliersWithPaginationQueryHandler : IRequestHandler<GetSuppliersWithPaginationQuery, PaginatedList<SupplierDto>>
    {
        private readonly IStoreContext _context;
        private readonly IMapper _mapper;

        public GetSuppliersWithPaginationQueryHandler(IStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<SupplierDto>> Handle(GetSuppliersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Suppliers
                .OrderBy(x => x.SupplierName)
                .ProjectTo<SupplierDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
