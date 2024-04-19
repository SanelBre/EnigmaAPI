using EnigmaAPI.Entities;

namespace EnigmaAPI.Services;

public interface IDocumentService
{
    public Task<Guid> GetClientIdAsync(string tenantId, string documentId);
    public Task<Guid> GetClientIdAsync(Guid tenantId, Guid documentId);
    public Task<string> GetDocumentContentAsync(string tenantId, string documentId);
    public Task<string> GetDocumentContentAsync(Guid tenantId, Guid documentId);
    public Task<string> AnonymizeDocumentContentBasedOnConfiguration(string content, string productCode);
    public Task<List<IDocument>> ListAllAsync();
    public Task<IDocument> GetDocumentAsync(string id);
}
