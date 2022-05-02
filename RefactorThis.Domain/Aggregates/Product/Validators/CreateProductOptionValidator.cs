using FluentValidation;
using RefactorThis.Domain.Aggregates.Product.Commands;

namespace RefactorThis.Domain.Aggregates.Product.Validators
{
    public class CreateProductOptionValidator : AbstractValidator<CreateProductOptionCommand>
    {
        public CreateProductOptionValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Option).NotEmpty();
            RuleFor(x => x.Option.Name).NotEmpty();
            RuleFor(x => x.Option.Description).NotEmpty();
        }
    }
}
