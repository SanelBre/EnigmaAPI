using Entities;

namespace Services;

public interface IClientService
{
    public Task<IClient> GetClientDataAsync(int tenantId, string documentId);
    public Task<IClient> GetWhitelistedClientDataAsync(int tenantId, string documentId);
}
