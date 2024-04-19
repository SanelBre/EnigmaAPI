namespace EnigmaAPI.Services;

public interface IDocumentService
{
    public Task<Guid> GetClientIdAsync(string tenantId, string documentId);
    public Task<Guid> GetClientIdAsync(Guid tenantId, Guid documentId);
}
