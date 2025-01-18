using Ecommerce.Application.Services;
using Ecommerce.CQRS.Features.Product.Query.Model;
using Ecommerce.DTOs.Product;
using MediatR;

namespace Ecommerce.CQRS.Features.Product.Query.Handler
{
    public class ProductHandler : IRequestHandler<GetProductBySubCatIdQuery, List<GetAllproductEnDTO>>
    {
        private readonly IProductService productService;
        public ProductHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<List<GetAllproductEnDTO>> Handle(GetProductBySubCatIdQuery request, CancellationToken cancellationToken)
        {
            var res = (await productService.GetAllProductPaginationEnBySubCatIdAsync(request.CategoryId));

            return res;
        }
    }
}
