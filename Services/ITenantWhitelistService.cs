namespace Services;

public interface ITenantWhitelistService
{
    public Task ThrowIfNotWhitelisted(int tenantId);
}
