using Entities;

namespace DataAccess;


public class Seeder
{
    private IRepository<IProduct> ProductRepository;
    private IRepository<ITenantWhitelist> TenantWhitelistRepository;
    private IRepository<ITenant> TenantRepository;
    private IRepository<IClient> ClientRepository;
    private IRepository<IClientWhitelist> ClientWhitelistRepository;
    private IRepository<ICompany> CompanyRepository;

    public Seeder(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        ProductRepository = scope.ServiceProvider.GetRequiredService<IRepository<IProduct>>();
        TenantWhitelistRepository = scope.ServiceProvider.GetRequiredService<IRepository<ITenantWhitelist>>();
        TenantRepository = scope.ServiceProvider.GetRequiredService<IRepository<ITenant>>();
        ClientRepository = scope.ServiceProvider.GetRequiredService<IRepository<IClient>>();
        ClientWhitelistRepository = scope.ServiceProvider.GetRequiredService<IRepository<IClientWhitelist>>();
        CompanyRepository = scope.ServiceProvider.GetRequiredService<IRepository<ICompany>>();
    }

    public async Task SeedDataAsync()
    {
        await SeedProductsAsync();
        await SeedTenantsWhitelistAsync();
        await SeedTenantsAsync();
        await SeedClientsAsync();
        await SeedClientWhitelistAsync();
        await SeedCompaniesAsync();
    }

    private async Task SeedProductsAsync()
    {
        var products = new List<IProduct>
        {
            new Product { Id = 1, ProductCode = "ProductA" },
            new Product { Id = 2, ProductCode = "ProductB" },
            new Product { Id = 3, ProductCode = "ProductC" },
        };

        int idCounter = 0;
        foreach (var product in products)
        {
            product.Id = idCounter++;
            await ProductRepository.AddAsync(product);
        }
    }

    private async Task SeedTenantsAsync()
    {
        var tenants = new List<ITenant>
        {
            new Tenant { Name = "Sunflower Apartments" },
            new Tenant { Name = "Evergreen Estates" },
            new Tenant { Name = "Golden Gate Offices" },
            new Tenant { Name = "Blue Sky Suites" },
            new Tenant { Name = "Meadowview Condos" },
            new Tenant { Name = "Oakwood Residences" },
        };

        int idCounter = 0;
        foreach (var tenant in tenants)
        {
            tenant.Id = idCounter++;
            await TenantRepository.AddAsync(tenant);
        }
    }

    private async Task SeedTenantsWhitelistAsync()
    {
        var whitelists = new List<ITenantWhitelist>
        {
            new TenantWhitelist { TenantId = 1 },
            new TenantWhitelist { TenantId = 3 },
            new TenantWhitelist { TenantId = 5 },
        };

        int idCounter = 0;
        foreach (var whitelist in whitelists)
        {
            whitelist.Id = idCounter++;
            await TenantWhitelistRepository.AddAsync(whitelist);
        }
    }

    private async Task SeedClientsAsync()
    {
        var clients = new List<IClient>
        {
            new Client
            {
                VAT = "001t",
                DocumentId = "document_1",
                TenantId = 1
            },
            new Client
            {
                VAT = "002t",
                DocumentId = "document_2",
                TenantId = 3
            },
            new Client
            {
                VAT = "003t",
                DocumentId = null,
                TenantId = 3
            },
            new Client
            {
                VAT = "004t",
                DocumentId = "document_3",
                TenantId = 5
            },
            new Client
            {
                VAT = "005t",
                DocumentId = null,
                TenantId = 0
            },
        };

        int idCounter = 0;
        foreach (var client in clients)
        {
            client.Id = idCounter++;
            await ClientRepository.AddAsync(client);
        }
    }

    private async Task SeedClientWhitelistAsync()
    {
        var clientWhitelists = new List<IClientWhitelist>
        {
            new ClientWhitelist { ClientId = 1, TenantId = 3 },
            new ClientWhitelist { ClientId = 3, TenantId = 2 },
        };

        int idCounter = 0;
        foreach (var whitelist in clientWhitelists)
        {
            whitelist.Id = idCounter++;
            await ClientWhitelistRepository.AddAsync(whitelist);
        }
    }

    private async Task SeedCompaniesAsync()
    {
        var companies = new List<ICompany>
        {
            new Company { VAT = "001t", CompanyType = CompanyType.Small },
            new Company { VAT = "002t", CompanyType = CompanyType.Medium },
            new Company { VAT = "003t", CompanyType = CompanyType.Large },
            new Company { VAT = "004t", CompanyType = CompanyType.Large },
            new Company { VAT = "005t", CompanyType = CompanyType.Medium },
        };

        int idCounter = 0;
        foreach (var company in companies)
        {
            company.Id = idCounter++;
            await CompanyRepository.AddAsync(company);
        }
    }
}

