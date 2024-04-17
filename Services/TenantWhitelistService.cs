
using DataAccess;
using Entities;
using Utils.Exceptions;

namespace Services;

public class TenantWhitelistService : ITenantWhitelistService
{
    private IRepository<ITenantWhitelist> TenantWhitelistRepo;

    public TenantWhitelistService(IRepository<ITenantWhitelist> tenantWhitelist)
    {
        TenantWhitelistRepo = tenantWhitelist;
    }

    public async Task ThrowIfNotWhitelisted(int tenantId)
    {
        var whitelistObject = await TenantWhitelistRepo.GetWhereAsync(tw => tw.TenantId == tenantId)
            ?? throw new ForbiddenException($"Tenant not whitelisted!");
    }
}
