using Entities;

namespace Services;

public interface IClientWhitelistService
{
    public Task ThrowIfNotWhitelisted(int clientId, int tenantId);
}
