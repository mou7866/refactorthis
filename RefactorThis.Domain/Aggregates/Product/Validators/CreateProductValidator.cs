using FluentValidation;
using RefactorThis.Domain.Aggregates.Product.Commands;

namespace RefactorThis.Domain.Aggregates.Product.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.DeliveryPrice).GreaterThan(0);
        }
    }
}
