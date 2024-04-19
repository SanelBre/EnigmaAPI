using EnigmaAPI.DataAccess;
using EnigmaAPI.Entities;
using EnigmaAPI.Utils.Exceptions;

namespace EnigmaAPI.Services;

public class TenantService : ITenantService
{

    private IRepository<ITenant> TenantRepo;
    private readonly ITenantWhitelistService TenantWhitelistService;

    public TenantService(IRepository<ITenant> tenant, ITenantWhitelistService tenantWhitelistService)
    {
        TenantRepo = tenant;
        TenantWhitelistService = tenantWhitelistService;
    }

    public async Task<ITenant> GetTenantAsync(string tenantId)
    {
        return await GetTenantAsync(new Guid(tenantId));
    }

    public async Task<ITenant> GetTenantAsync(Guid tenantId)
    {
        var tenantData = await TenantRepo.GetWhereAsync(c => c.Id == tenantId)
            ?? throw new NotFoundException($"Did not find the tenant for the provided Id ({tenantId})");

        return tenantData;
    }

    public async Task<ITenant> GetWhitelistedTenantAsync(string tenantId)
    {
        return await GetWhitelistedTenantAsync(new Guid(tenantId));
    }

    public async Task<ITenant> GetWhitelistedTenantAsync(Guid tenantId)
    {
        var tenantData = await GetTenantAsync(tenantId);

        await TenantWhitelistService.ThrowIfNotWhitelisted(tenantData.Id);

        return tenantData;
    }
}
