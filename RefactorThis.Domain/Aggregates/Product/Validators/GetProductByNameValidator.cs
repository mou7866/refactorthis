using FluentValidation;
using RefactorThis.Domain.Aggregates.Product.Queries;

namespace RefactorThis.Domain.Aggregates.Product.Validators
{
    public class GetProductByNameValidator : AbstractValidator<GetProductByNameQuery>
    {
        public GetProductByNameValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
