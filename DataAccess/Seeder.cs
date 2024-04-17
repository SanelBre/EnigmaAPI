using Entities;

namespace DataAccess;


public class Seeder
{
    private IRepository<IProduct> ProductRepository;
    private IRepository<ITenant> TenantRepository;
    private IRepository<IClient> ClientRepository;
    private IRepository<IClientWhitelist> ClientWhitelistRepository;

    public Seeder(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        ProductRepository = scope.ServiceProvider.GetRequiredService<IRepository<IProduct>>();
        TenantRepository = scope.ServiceProvider.GetRequiredService<IRepository<ITenant>>();
        ClientRepository = scope.ServiceProvider.GetRequiredService<IRepository<IClient>>();
        ClientWhitelistRepository = scope.ServiceProvider.GetRequiredService<IRepository<IClientWhitelist>>();
    }

    public async Task SeedDataAsync()
    {
        await SeedProductsAsync();
        await SeedTenantsAsync();
        await SeedClientsAsync();
        await SeedClientWhitelistAsync();
    }

    private async Task SeedProductsAsync()
    {
        var products = new List<IProduct>
            {
                new Product { Id = 1, ProductCode = "ProductA" },
                new Product { Id = 2, ProductCode = "ProductB" },
                new Product { Id = 3, ProductCode = "ProductC" },
            };

        foreach (var product in products)
        {
            await ProductRepository.AddAsync(product);
        }
    }

    private async Task SeedTenantsAsync()
    {
        var tenants = new List<ITenant>
            {
                new Tenant { Id = 0, IsWhitelisted = false },
                new Tenant { Id = 1, IsWhitelisted = true },
                new Tenant { Id = 2, IsWhitelisted = false },
                new Tenant { Id = 3, IsWhitelisted = true },
                new Tenant { Id = 4, IsWhitelisted = false },
                new Tenant { Id = 5, IsWhitelisted = true },
            };

        foreach (var tenant in tenants)
        {
            await TenantRepository.AddAsync(tenant);
        }
    }

    private async Task SeedClientsAsync()
    {
        var clients = new List<IClient>
        {
            new Client
            {
                Id = 0,
                VAT = "001t",
                CompanyType = CompanyType.Small,
                DocumentId = "document_id_1",
                RegisterNumber = 1000,
                TenantId = 1
            },
            new Client
            {
                Id = 1,
                VAT = "002t",
                CompanyType = CompanyType.Medium,
                DocumentId = "document_id_2",
                RegisterNumber = 2000,
                TenantId = 3
            },
            new Client
            {
                Id = 2,
                VAT = "003t",
                CompanyType = CompanyType.Medium,
                DocumentId = null,
                RegisterNumber = 3000,
                TenantId = 3
            },
            new Client
            {
                Id = 3,
                VAT = "004t",
                CompanyType = CompanyType.Large,
                DocumentId = "document_id_3",
                RegisterNumber = 4000,
                TenantId = 5
            },
            new Client
            {
                Id = 4,
                VAT = "005t",
                CompanyType = CompanyType.Large,
                DocumentId = null,
                RegisterNumber = 5000,
                TenantId = 0
            },
        };

        foreach (var client in clients)
        {
            await ClientRepository.AddAsync(client);
        }
    }

    private async Task SeedClientWhitelistAsync()
    {
        var clientWhitelists = new List<IClientWhitelist>
        {
            new ClientWhitelist { Id = 0, ClientId = 1, TenantId = 3 },
            new ClientWhitelist { Id = 0, ClientId = 3, TenantId = 2 },
        };

        foreach (var whitelist in clientWhitelists)
        {
            await ClientWhitelistRepository.AddAsync(whitelist);
        }
    }
}
