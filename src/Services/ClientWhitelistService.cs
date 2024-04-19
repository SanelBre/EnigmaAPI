
using EnigmaAPI.DataAccess;
using EnigmaAPI.Entities;
using EnigmaAPI.Utils.Exceptions;

namespace EnigmaAPI.Services;

public class ClientWhitelistService : IClientWhitelistService
{
    private IRepository<IClientWhitelist> ClientWhitelistRepo;

    public ClientWhitelistService(IRepository<IClientWhitelist> clientWhitelist)
    {
        ClientWhitelistRepo = clientWhitelist;
    }

    public async Task ThrowIfNotWhitelisted(string clientId)
    {
        await ThrowIfNotWhitelisted(new Guid(clientId));
    }

    public async Task ThrowIfNotWhitelisted(Guid clientId)
    {
        var whitelistObject = await ClientWhitelistRepo.GetWhereAsync(cw => cw.ClientId == clientId)
            ?? throw new ForbiddenException($"Client not whitelisted!");
    }
}
