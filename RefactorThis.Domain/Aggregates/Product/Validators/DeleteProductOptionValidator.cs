using FluentValidation;
using RefactorThis.Domain.Aggregates.Product.Commands;

namespace RefactorThis.Domain.Aggregates.Product.Validators
{
    public class DeleteProductOptionValidator : AbstractValidator<DeleteProductOptionCommand>
    {
        public DeleteProductOptionValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();
        }
    }
}
