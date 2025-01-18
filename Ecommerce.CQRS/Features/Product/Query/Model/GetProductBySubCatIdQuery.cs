using Ecommerce.DTOs.Product;
using MediatR;

namespace Ecommerce.CQRS.Features.Product.Query.Model
{
    public class GetProductBySubCatIdQuery : IRequest<List<GetAllproductEnDTO>>
    {
        public int CategoryId { get; set; }

    }
}
