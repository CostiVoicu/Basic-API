using Project.Core.Mapping;
using Project.Database.Dtos.Response;
using Project.Database.Repositories;

namespace Project.Core.Services
{
    public class ProductsService
    {
        private ProductsRepository productsRepository { get; set; }
        public ProductsService(ProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public GetProductDetailsResponse GetProductDetails(int productId)
        {
            var product = productsRepository.GetById(productId);

            var result = product.ToGetProductDetailsResponse();

            return result;
        }
    }
}