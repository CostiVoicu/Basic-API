using Microsoft.EntityFrameworkCore;
using Project.Database.Context;
using Project.Database.Entities;
using System.Threading.Tasks;

namespace Project.Database.Repositories
{
    public class ProductsRepository : BaseRepository
    {
        public ProductsRepository(PetShopDbContext petShopDbContext) : base(petShopDbContext)
        {
        }

        public Product GetById(int productId)
        {
            var result = petShopDbContext.Products
                .Include(e => e.Store)

                .Where(e => e.Id == productId)

                .FirstOrDefault();

            return result;
        }
    }
}
