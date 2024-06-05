using Project.Core.Services;
using Project.Database.Context;
using Project.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Project.Api
{
    public static class StartupConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ProductsService>();
            services.AddScoped<AuthService>();
            services.AddScoped<UsersService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<PetShopDbContext>();
            services.AddScoped<DbContext, PetShopDbContext>();

            services.AddScoped<ProductsRepository>();
            services.AddScoped<UsersRepository>();
            services.AddScoped<RoleRepository>();
        }
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "PetShop API", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    }
                });
            });
        }
    }
}
