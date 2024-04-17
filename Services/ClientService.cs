using DataAccess;
using Entities;
using Utils.Exceptions;

namespace Services;

public class ClientService : IClientService
{

    private IRepository<IClient> ClientRepo;
    private readonly IClientWhitelistService ClientWhitelistService;

    public ClientService(IRepository<IClient> client, IClientWhitelistService clientWhitelistService)
    {
        ClientRepo = client;
        ClientWhitelistService = clientWhitelistService;
    }

    public async Task<IClient> GetClientDataAsync(int tenantId, string documentId)
    {
        var clientData = await ClientRepo.GetWhereAsync(c => c.TenantId == tenantId && c.DocumentId == documentId)
            ?? throw new NotFoundException($"Did not find the client for the provided tenantId ({tenantId}) and documentId ({documentId})");

        return clientData;
    }

    public async Task<IClient> GetWhitelistedClientDataAsync(int tenantId, string documentId)
    {
        var clientData = await GetClientDataAsync(tenantId, documentId);

        await ClientWhitelistService.ThrowIfNotWhitelisted(clientData.Id, tenantId);

        return clientData;
    }
}
