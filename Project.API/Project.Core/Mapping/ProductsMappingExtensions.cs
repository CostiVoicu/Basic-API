using Project.Database.Dtos.Common;
using Project.Database.Dtos.Response;
using Project.Database.Entities;

namespace Project.Core.Mapping
{
    public static class ProductsMappingExtensions
    {
        public static GetProductDetailsResponse ToGetProductDetailsResponse(this Product entity)
        {
            if (entity == null) return null;

            var result = new GetProductDetailsResponse();
            result.Id = entity.Id;
            result.Name = entity.Name;
            result.Price = entity.Price;
            result.StoreId = entity.StoreId;
            result.Store = new StoreDto();

            if (entity.Store == null)
                result.Store = null;
            else
            {
                result.Store.Id = entity.Store.Id;
                result.Store.Name= entity.Store.Name;
            }

            return result;
        }
    }
}
