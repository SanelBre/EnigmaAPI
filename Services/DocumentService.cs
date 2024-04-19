
using EnigmaAPI.DataAccess;
using EnigmaAPI.Entities;
using EnigmaAPI.Utils.Exceptions;

namespace EnigmaAPI.Services;

public class DocumentService : IDocumentService
{
    private IRepository<IDocument> DocumentRepo;

    public DocumentService(IRepository<IDocument> document)
    {
        DocumentRepo = document;
    }

    public async Task<Guid> GetClientIdAsync(string tenantId, string documentId)
    {
        return await GetClientIdAsync(new Guid(tenantId), new Guid(documentId));
    }
    public async Task<Guid> GetClientIdAsync(Guid tenantId, Guid documentId)
    {
        var doc = await DocumentRepo.GetWhereAsync(d => d.Id == documentId && d.TenantId == tenantId)
            ?? throw new NotFoundException("Document not found!");

        return doc.ClientId;
    }
}

