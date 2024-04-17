using Entities;

namespace Services;

public interface ITenantService
{
    public Task<ITenant> GetTenantAsync(int tenantId);
    public Task<ITenant> GetWhitelistedTenantAsync(int tenantId);
}
