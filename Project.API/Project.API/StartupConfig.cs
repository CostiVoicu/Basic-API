using Project.Core.Services;
using Project.Database.Context;
using Project.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Project.Api
{
    public static class StartupConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ProductsService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<PetShopDbContext>();
            services.AddScoped<DbContext, PetShopDbContext>();

            services.AddScoped<ProductsRepository>();
        }
    }
}
