
using EnigmaAPI.DataAccess;
using EnigmaAPI.Entities;
using EnigmaAPI.Utils.Exceptions;

namespace EnigmaAPI.Services;

public class TenantWhitelistService : ITenantWhitelistService
{
    private IRepository<ITenantWhitelist> TenantWhitelistRepo;

    public TenantWhitelistService(IRepository<ITenantWhitelist> tenantWhitelist)
    {
        TenantWhitelistRepo = tenantWhitelist;
    }

    public async Task ThrowIfNotWhitelisted(string tenantId)
    {
        await ThrowIfNotWhitelisted(new Guid(tenantId));
    }

    public async Task ThrowIfNotWhitelisted(Guid tenantId)
    {
        var whitelistObject = await TenantWhitelistRepo.GetWhereAsync(tw => tw.TenantId == tenantId)
            ?? throw new ForbiddenException($"Tenant not whitelisted!");
    }
}
