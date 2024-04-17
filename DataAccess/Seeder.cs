using Entities;

namespace DataAccess;


public class Seeder
{
    private IRepository<IProduct> ProductRepository;
    private IRepository<ITenant> TenantRepository;
    private IRepository<IClient> ClientRepository;

    public Seeder(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        ProductRepository = scope.ServiceProvider.GetRequiredService<IRepository<IProduct>>();
        TenantRepository = scope.ServiceProvider.GetRequiredService<IRepository<ITenant>>();
        ClientRepository = scope.ServiceProvider.GetRequiredService<IRepository<IClient>>();
    }

    public async Task SeedDataAsync()
    {
        await SeedProductsAsync();
        await SeedTenantsAsync();
        await SeedClientsAsync();
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
                    IsWhitelisted = true,
                    CompanyType = CompanyType.Small,
                    DocumentId = "document_id_1",
                    RegisterNumber = 1000,
                    TenantId = (await TenantRepository.GetAllAsync()).Single(t => t.Id == 1).Id
                },
                new Client
                {
                    Id = 1,
                    VAT = "002t",
                    IsWhitelisted = true,
                    CompanyType = CompanyType.Medium,
                    DocumentId = "document_id_2",
                    RegisterNumber = 2000,
                    TenantId = (await TenantRepository.GetAllAsync()).Single(t => t.Id == 3).Id
                },
                new Client
                {
                    Id = 2,
                    VAT = "003t",
                    IsWhitelisted = true,
                    CompanyType = CompanyType.Medium,
                    DocumentId = null,
                    RegisterNumber = 3000,
                    TenantId = (await TenantRepository.GetAllAsync()).Single(t => t.Id == 3).Id
                },
                new Client
                {
                    Id = 3,
                    VAT = "004t",
                    IsWhitelisted = false,
                    CompanyType = CompanyType.Large,
                    DocumentId = "document_id_3",
                    RegisterNumber = 4000,
                    TenantId = (await TenantRepository.GetAllAsync()).Single(t => t.Id == 5).Id
                },
                new Client
                {
                    Id = 4,
                    VAT = "005t",
                    IsWhitelisted = false,
                    CompanyType = CompanyType.Large,
                    DocumentId = null,
                    RegisterNumber = 5000,
                    TenantId = (await TenantRepository.GetAllAsync()).Single(t => t.Id == 0).Id
                },
            };

        foreach (var client in clients)
        {
            await ClientRepository.AddAsync(client);
        }
    }
}

