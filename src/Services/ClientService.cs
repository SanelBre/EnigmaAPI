using EnigmaAPI.DataAccess;
using EnigmaAPI.Entities;
using EnigmaAPI.Utils.Exceptions;

namespace EnigmaAPI.Services;

public class ClientService : IClientService
{

    private IRepository<IClient> ClientRepo;
    private readonly IClientWhitelistService ClientWhitelistService;

    public ClientService(IRepository<IClient> client, IClientWhitelistService clientWhitelistService)
    {
        ClientRepo = client;
        ClientWhitelistService = clientWhitelistService;
    }

    public async Task<IClient> GetClientDataByIdAsync(string id)
    {
        return await GetClientDataByIdAsync(new Guid(id));
    }

    public async Task<IClient> GetClientDataByIdAsync(Guid id)
    {
        var clientData = await ClientRepo.GetWhereAsync(c => c.Id == id)
            ?? throw new NotFoundException($"Did not find the client for the given client id ({id.ToString()})");

        return clientData;
    }

    public async Task<IClient> GetWhitelistedClientDataByIdAsync(string id)
    {
        return await GetWhitelistedClientDataByIdAsync(new Guid(id));
    }

    public async Task<IClient> GetWhitelistedClientDataByIdAsync(Guid id)
    {
        var clientData = await GetClientDataByIdAsync(id);

        await ClientWhitelistService.ThrowIfNotWhitelisted(id);

        return clientData;
    }
}
