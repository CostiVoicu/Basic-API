using Project.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Project.Core.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private ProductsService productsService { get; set; }

        public ProductsController(
            ProductsService productsService
            )
        {
            this.productsService = productsService;
        }

        [HttpGet]
        [Route("{productId}/get-details")]
        public IActionResult GetProductDetails([FromRoute] int productId)
        {
            var result = productsService.GetProductDetails(productId);

            return Ok(result);
        }
    }
}
