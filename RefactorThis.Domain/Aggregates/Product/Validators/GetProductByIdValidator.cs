using FluentValidation;
using RefactorThis.Domain.Aggregates.Product.Queries;

namespace RefactorThis.Domain.Aggregates.Product.Validators
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
