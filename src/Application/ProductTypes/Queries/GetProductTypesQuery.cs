using Application.Common.Interfaces;
using Application.Products.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductTypes.Queries
{
    public class GetProductTypesQuery : IRequest<IList<ProductTypeDto>>
    {
    }

    public class GetProductTypesQueryHandler : IRequestHandler<GetProductTypesQuery, IList<ProductTypeDto>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetProductTypesQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ProductTypeDto>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            return await _context.ProductTypes
                .OrderBy(x => x.Name)
                .ProjectTo<ProductTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
