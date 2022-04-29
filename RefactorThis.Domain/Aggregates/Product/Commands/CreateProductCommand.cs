using MediatR;
using RefactorThis.Domain.Aggregates.Product.Reponses;

namespace RefactorThis.Domain.Aggregates.Product.Commands
{
    public class CreateProductCommand : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }
    }
}
