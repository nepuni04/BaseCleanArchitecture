using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int ProductTypeId { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IAppDbContext _context;
        public CreateProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new Product
            {
                Name = request.Name,
                Summary = request.Summary,
                Description = request.Description,
                PictureUrl = request.PictureUrl,
                Price = request.Price,
                ProductTypeId = request.ProductTypeId
            };

            newProduct.DomainEvents.Add(new ProductCreatedEvent(newProduct));

            _context.Products.Add(newProduct);

            await _context.SaveChangesAsync(cancellationToken);

            return newProduct.Id;
        }

    }
}
