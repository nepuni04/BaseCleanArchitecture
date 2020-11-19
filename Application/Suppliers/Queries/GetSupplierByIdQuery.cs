using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Suppliers.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Suppliers.Queries
{
    public class GetSupplierByIdQuery : IRequest<SupplierDto>
    {
        public int Id { get; set; }
    }

    public class GetSupplierByIdQueryHander : IRequestHandler<GetSupplierByIdQuery, SupplierDto>
    {
        private readonly IStoreContext _context;
        private readonly IMapper _mapper;

        public GetSupplierByIdQueryHander(IStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SupplierDto> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Suppliers
                .ProjectTo<SupplierDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (product == null)
            {
                throw new NotFoundException(nameof(SupplierDto), request.Id);
            }

            return product;
        }
    }
}
