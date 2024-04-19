using EnigmaAPI.Entities;

namespace EnigmaAPI.Services;

public interface IClientService
{
    public Task<IClient> GetClientDataByIdAsync(string id);
    public Task<IClient> GetClientDataByIdAsync(Guid id);
    public Task<IClient> GetWhitelistedClientDataByIdAsync(string id);
    public Task<IClient> GetWhitelistedClientDataByIdAsync(Guid id);
}
