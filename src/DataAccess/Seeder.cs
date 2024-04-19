using EnigmaAPI.Entities;

namespace EnigmaAPI.DataAccess;


public class Seeder
{
    private IRepository<IProduct> ProductRepository;
    private IRepository<IDocument> DocumentRepository;
    private IRepository<ITenantWhitelist> TenantWhitelistRepository;
    private IRepository<ITenant> TenantRepository;
    private IRepository<IClient> ClientRepository;
    private IRepository<IClientWhitelist> ClientWhitelistRepository;
    private IRepository<ICompany> CompanyRepository;

    public Seeder(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        ProductRepository = scope.ServiceProvider.GetRequiredService<IRepository<IProduct>>();
        DocumentRepository = scope.ServiceProvider.GetRequiredService<IRepository<IDocument>>();
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
        await SeedDocumentsAsync();
    }

    private async Task SeedProductsAsync()
    {
        var products = Samples.Products;

        foreach (var product in products)
        {
            await ProductRepository.AddAsync(product);
        }
    }

    private async Task SeedTenantsAsync()
    {
        var tenants = Samples.Tenants;

        foreach (var tenant in tenants)
        {
            await TenantRepository.AddAsync(tenant);
        }
    }

    private async Task SeedTenantsWhitelistAsync()
    {
        var whitelists = Samples.TenantWhitelist;

        foreach (var whitelist in whitelists)
        {
            await TenantWhitelistRepository.AddAsync(whitelist);
        }
    }

    private async Task SeedClientsAsync()
    {
        var clients = Samples.Clients;

        foreach (var client in clients)
        {
            await ClientRepository.AddAsync(client);
        }
    }

    private async Task SeedClientWhitelistAsync()
    {
        var whitelists = Samples.ClientsWhitelist;

        foreach (var whitelist in whitelists)
        {
            await ClientWhitelistRepository.AddAsync(whitelist);
        }
    }

    private async Task SeedCompaniesAsync()
    {
        var companies = Samples.Companies;

        foreach (var company in companies)
        {
            await CompanyRepository.AddAsync(company);
        }
    }

    private async Task SeedDocumentsAsync()
    {
        var documents = Samples.Documents;

        foreach (var document in documents)
        {
            await DocumentRepository.AddAsync(document);
        }
    }
}

