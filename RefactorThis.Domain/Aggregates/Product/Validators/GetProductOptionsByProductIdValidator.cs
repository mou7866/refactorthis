using FluentValidation;
using RefactorThis.Domain.Aggregates.Product.Queries;

namespace RefactorThis.Domain.Aggregates.Product.Validators
{
    public class GetProductOptionsByProductIdValidator : AbstractValidator<GetProductOptionsByProductIdQuery>
    {
        public GetProductOptionsByProductIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
