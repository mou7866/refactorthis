using FluentValidation;
using RefactorThis.Domain.Aggregates.Product.Commands;

namespace RefactorThis.Domain.Aggregates.Product.Validators
{
    public class UpdateProductOptionValidator : AbstractValidator<UpdateProductOptionCommand>
    {
        public UpdateProductOptionValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();
        }
    }
}
