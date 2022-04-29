using MediatR;
using RefactorThis.Domain.Aggregates.Product.Responses;

namespace RefactorThis.Domain.Aggregates.Product.Queries
{
    public class GetProductByNameQuery : IRequest<GetProductByNameResponse>
    {
        public GetProductByNameQuery(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
