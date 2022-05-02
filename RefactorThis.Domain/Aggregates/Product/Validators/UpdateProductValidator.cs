using FluentValidation;
using RefactorThis.Domain.Aggregates.Product.Commands;

namespace RefactorThis.Domain.Aggregates.Product.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Product).NotEmpty();
            RuleFor(x => x.Product.Name).NotEmpty();
            RuleFor(x => x.Product.Description).NotEmpty();
            RuleFor(x => x.Product.Price).GreaterThan(0);
            RuleFor(x => x.Product.DeliveryPrice).GreaterThan(0);
        }
    }
}
