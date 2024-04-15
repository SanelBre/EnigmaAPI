using DataAccess;

namespace Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepository<T>(this IServiceCollection services) where T : class
    {
        services.AddSingleton<IRepository<T>, Repository<T>>(provider =>
        {
            return new Repository<T>(new MemoryStorage<T>());
        });

        return services;
    }
}

