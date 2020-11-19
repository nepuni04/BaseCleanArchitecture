using FluentValidation;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Name).NotEmpty().MaximumLength(80);

            RuleFor(x => x.Description).NotEmpty().MaximumLength(180);

            RuleFor(x => x.ProductTypeId).NotEmpty();

            RuleFor(x => x.Price).NotEmpty();

            RuleFor(x => x.PictureUrl).NotEmpty().MaximumLength(50);
        }
    }
}
