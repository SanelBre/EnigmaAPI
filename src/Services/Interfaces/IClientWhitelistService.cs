namespace EnigmaAPI.Services;

public interface IClientWhitelistService
{
    public Task ThrowIfNotWhitelisted(string clientId);
    public Task ThrowIfNotWhitelisted(Guid clientId);
}
