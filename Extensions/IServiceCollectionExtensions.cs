using DataAccess;
using Entities;
using Services;

namespace Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRepository<T>(this IServiceCollection services) where T : IEntity
        {
            services.AddSingleton<IDataStorage<T>, MemoryStorage<T>>();
            services.AddSingleton<IRepository<T>, Repository<T>>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddRepository<IProduct>();
            services.AddRepository<ITenant>();
            services.AddRepository<IClient>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
