
using DataAccess;
using Entities;
using Utils.Exceptions;

namespace Services;

public class ClientWhitelistService : IClientWhitelistService
{
    private IRepository<IClientWhitelist> ClientWhitelistRepo;

    public ClientWhitelistService(IRepository<IClientWhitelist> clientWhitelist)
    {
        ClientWhitelistRepo = clientWhitelist;
    }

    public async Task ThrowIfNotWhitelisted(int clientId, int tenantId)
    {
        var whitelistObject = await ClientWhitelistRepo.GetWhereAsync(cw => cw.ClientId == clientId && cw.TenantId == tenantId)
            ?? throw new ForbiddenException($"Client not whitelisted!");
    }
}
