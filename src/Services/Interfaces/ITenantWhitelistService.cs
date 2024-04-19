namespace EnigmaAPI.Services;

public interface ITenantWhitelistService
{
    public Task ThrowIfNotWhitelisted(string tenantId);
    public Task ThrowIfNotWhitelisted(Guid tenantId);
}
