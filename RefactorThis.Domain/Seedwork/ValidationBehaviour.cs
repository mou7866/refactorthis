using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RefactorThis.Domain.Seedwork
{
    [ExcludeFromCodeCoverage]
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
           where TRequest : IRequest<TResponse>
           where TResponse : BaseResponse, new()
    {
        public List<IValidator<TRequest>> Validators { get; init; }

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            Validators = validators is not null ? validators.ToList() : new();
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (!Validators.Any()) return await next();

            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                Validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .SelectMany(validation => validation.Errors)
                .Where(failure => failure is not null)
                .Distinct()
                .ToList();

            var errors = failures.Any()
                ? new TResponse
                {
                    Errors = failures.Select(error =>
                    new MessageBody
                    {
                        Code = error.ErrorCode,
                        Message = error.ErrorMessage,
                        Technical = false,
                        Type = ResponseType.FAILURE
                    }).ToList()
                }
                : await next();

            return errors;
        }
    }
}