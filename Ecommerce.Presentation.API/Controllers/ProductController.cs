using Ecommerce.Application.Services;
using Ecommerce.Application.Services.Product_Facility;
using Ecommerce.Application.Services.ServicesCategories;
using Ecommerce.CQRS.Features.Product.Query.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ISubCategoryServices subCategoryService;
        private readonly ISubCatFacilityService subcatfacilityService;
        private readonly IFacillityService facilityService;
        private readonly IMediator mediator;
        private readonly IImageService imageService;
        private readonly IProductFacilityServices productfacilityServices;
        public ProductController(ISubCategoryServices _subCategoryService,
            IProductService _productService,
            IImageService _imageService, IProductFacilityServices _productfacilityServices,
            ISubCatFacilityService _subcatfacilityService, IFacillityService _facilityService, IMediator mediator)
        {
            productService = _productService;
            subCategoryService = _subCategoryService;
            imageService = _imageService;
            subcatfacilityService = _subcatfacilityService;
            facilityService = _facilityService;
            this.mediator = mediator;
            productfacilityServices = _productfacilityServices;
        }

        [HttpGet("ProductPagination/{CatId:int}")]
        public async Task<IActionResult> GetAllProductbyCategory(int CatId)
        {
            #region Old Version
            //var res = (await productService.GetAllProductPaginationEnBySubCatIdAsync(CatId));
            //if (res != null)
            //    return Ok(res);
            //else
            //{
            //    return BadRequest(ModelState);
            //} 
            #endregion


            var res = await mediator.Send(new GetProductBySubCatIdQuery() { CategoryId = CatId });
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();

        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await productService.GetAllAsync(1, 10);

            return Ok(products);
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPagination(int Subcatid, int PageNumber, int Count, string? searchTerm, decimal? price)
        {
            var products = await productService.GetAllPaginationAsync(Subcatid, PageNumber, Count, searchTerm, price);
            return Ok(products);
        }

        [HttpGet("GetOne")]
        public async Task<IActionResult> GetOne(int id)
        {
            var product = await productService.GetByIdApi(id);
            return Ok(product);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchProduct(string? ProductName, decimal? price)
        {
            var product = await productService.SearchByNameAsync(1, 4, ProductName, price);
            return Ok(product);
        }

    }
}
