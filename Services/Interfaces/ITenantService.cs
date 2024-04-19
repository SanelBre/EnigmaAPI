using EnigmaAPI.Entities;

namespace EnigmaAPI.Services;

public interface ITenantService
{
    public Task<ITenant> GetTenantAsync(string tenantId);
    public Task<ITenant> GetTenantAsync(Guid tenantId);
    public Task<ITenant> GetWhitelistedTenantAsync(string tenantId);
    public Task<ITenant> GetWhitelistedTenantAsync(Guid tenantId);
}
