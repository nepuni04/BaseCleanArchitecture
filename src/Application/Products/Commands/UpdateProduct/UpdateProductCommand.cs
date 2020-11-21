using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int ProductTypeId { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IAppDbContext context;

        public UpdateProductCommandHandler(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            entity.Name = request.Name;
            entity.Summary = request.Summary;
            entity.Description = request.Description;
            entity.PictureUrl = request.PictureUrl;
            entity.Price = request.Price;
            entity.ProductTypeId = request.ProductTypeId;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
