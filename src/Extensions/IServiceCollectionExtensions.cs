using EnigmaAPI.DataAccess;
using EnigmaAPI.Services;
using EnigmaAPI.Entities;

namespace EnigmaAPI.Extensions
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
            services.AddRepository<IDocument>();
            services.AddRepository<ITenantWhitelist>();
            services.AddRepository<ITenant>();
            services.AddRepository<IClient>();
            services.AddRepository<IClientWhitelist>();
            services.AddRepository<ICompany>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<ITenantWhitelistService, TenantWhitelistService>();
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IClientWhitelistService, ClientWhitelistService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICompanyService, CompanyService>();

            return services;
        }
    }
}
