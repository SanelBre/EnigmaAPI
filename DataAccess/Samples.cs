using EnigmaAPI.Entities;

namespace EnigmaAPI.DataAccess;

public class Samples
{
    public static List<IProduct> Products = GetProductSamples();
    public static List<ITenant> Tenants = GetTenantSamples();
    public static List<ITenantWhitelist> TenantWhitelist = GetTenantWhitelistSamples();
    public static List<IClient> Clients = GetClientSamples();
    public static List<IClientWhitelist> ClientsWhitelist = GetClientWhitelistSamples();
    public static List<ICompany> Companies = GetCompanySamples();
    public static List<IDocument> Documents = GetDocumentSamples();

    private static List<IProduct> GetProductSamples()
    {
        var products = new List<IProduct>
        {
            new Product { Id = new Guid("a01669d4-1e24-4c1a-b67d-9a8d5277c8bb"), ProductCode = "ProductA" },
            new Product { Id = new Guid("a11669d4-1e24-4c1a-b67d-9a8d5277c8bb"), ProductCode = "ProductB" },
            new Product { Id = new Guid("a21669d4-1e24-4c1a-b67d-9a8d5277c8bb"), ProductCode = "ProductC" },
        };

        return products;
    }

    private static List<ITenant> GetTenantSamples()
    {
        var tenants = new List<ITenant>
        {
            new Tenant { Id = new Guid("b01669d4-1e24-4c1a-b67d-9a8d5277c8bb"), Name = "Sunflower Apartments" },
            new Tenant { Id = new Guid("b11669d4-1e24-4c1a-b67d-9a8d5277c8bb"), Name = "Evergreen Estates" },
            new Tenant { Id = new Guid("b21669d4-1e24-4c1a-b67d-9a8d5277c8bb"), Name = "Golden Gate Offices" },
            new Tenant { Id = new Guid("b31669d4-1e24-4c1a-b67d-9a8d5277c8bb"), Name = "Blue Sky Suites" },
            new Tenant { Id = new Guid("b41669d4-1e24-4c1a-b67d-9a8d5277c8bb"), Name = "Meadowview Condos" },
            new Tenant { Id = new Guid("b51669d4-1e24-4c1a-b67d-9a8d5277c8bb"), Name = "Oakwood Residences" },
        };

        return tenants;
    }

    private static List<ITenantWhitelist> GetTenantWhitelistSamples()
    {
        var whitelists = new List<ITenantWhitelist>
        {
            new TenantWhitelist { Id = Guid.NewGuid(), TenantId = Tenants[1].Id },
            new TenantWhitelist { Id = Guid.NewGuid(), TenantId = Tenants[3].Id },
            new TenantWhitelist { Id = Guid.NewGuid(), TenantId = Tenants[5].Id },
        };

        return whitelists;
    }

    private static List<IClient> GetClientSamples()
    {
        var clients = new List<IClient>
        {
            new Client
            {
                Id = Guid.NewGuid(),
                VAT = "VAT1",
                TenantId = Tenants[1].Id
            },
            new Client
            {
                Id = Guid.NewGuid(),
                VAT = "VAT2",
                TenantId = Tenants[3].Id
            },
            new Client
            {
                Id = Guid.NewGuid(),
                VAT = "VAT3",
                TenantId = Tenants[3].Id
            },
            new Client
            {
                Id = Guid.NewGuid(),
                VAT = "VAT4",
                TenantId = Tenants[5].Id
            },
            new Client
            {
                Id = Guid.NewGuid(),
                VAT = "VAT5",
                TenantId = Tenants[0].Id
            },
        };

        return clients;
    }

    private static List<IClientWhitelist> GetClientWhitelistSamples()
    {
        var whitelists = new List<IClientWhitelist>
        {
            new ClientWhitelist { Id = Guid.NewGuid(), ClientId = Clients[0].Id },
            new ClientWhitelist { Id = Guid.NewGuid(), ClientId = Clients[1].Id },
        };

        return whitelists;
    }

    private static List<ICompany> GetCompanySamples()
    {
        var companies = new List<ICompany>
        {
            new Company { Id = Guid.NewGuid(), VAT = "VAT1", RegisterNumber = 1001, CompanyType = CompanyType.Small },
            new Company { Id = Guid.NewGuid(), VAT = "VAT2", RegisterNumber = 1002, CompanyType = CompanyType.Medium },
            new Company { Id = Guid.NewGuid(), VAT = "VAT3", RegisterNumber = 1003, CompanyType = CompanyType.Large },
            new Company { Id = Guid.NewGuid(), VAT = "VAT4", RegisterNumber = 1004, CompanyType = CompanyType.Large },
            new Company { Id = Guid.NewGuid(), VAT = "VAT5", RegisterNumber = 1005, CompanyType = CompanyType.Medium }
        };

        return companies;
    }

    private static List<IDocument> GetDocumentSamples()
    {
        var documents = new List<IDocument>
        {
            new Document {
                Id = new Guid("d00669d4-1e24-4c1a-b67d-9a8d5277c8bb"),
                TenantId = Tenants[1].Id,
                ClientId = Clients[1].Id,
                URI = "/Statics/1/document.json"
            },
            new Document {
                Id = new Guid("d10669d4-1e24-4c1a-b67d-9a8d5277c8bb"),
                TenantId = Tenants[3].Id,
                ClientId = Clients[2].Id,
                URI = "/Statics/2/document.json"
            },
            new Document {
                Id = new Guid("d20669d4-1e24-4c1a-b67d-9a8d5277c8bb"),
                TenantId = Tenants[5].Id,
                ClientId = Clients[3].Id,
                URI = "/Statics/3/document.json"
            },
        };

        return documents;
    }
}
