using EnigmaAPI.DataAccess;

namespace EnigmaAPI.Extensions;

public static class IServiceProviderExtensions
{
    public static async Task SeedDataAsync(this IServiceProvider services)
    {
        var dataSeeder = services.GetRequiredService<Seeder>();

        await dataSeeder.SeedDataAsync();

        return;
    }
}
