
using System.Text.RegularExpressions;
using EnigmaAPI.DataAccess;
using EnigmaAPI.Entities;
using EnigmaAPI.Utils.Exceptions;
using EnigmaAPI.Extensions;

namespace EnigmaAPI.Services;

public class DocumentService : IDocumentService
{
    private IRepository<IDocument> DocumentRepo;
    private IProductService ProductService;

    public DocumentService(IRepository<IDocument> document, IProductService productService)
    {
        DocumentRepo = document;
        ProductService = productService;
    }

    public async Task<Guid> GetClientIdAsync(string tenantId, string documentId)
    {
        return await GetClientIdAsync(new Guid(tenantId), new Guid(documentId));
    }
    public async Task<Guid> GetClientIdAsync(Guid tenantId, Guid documentId)
    {
        var doc = await DocumentRepo.GetWhereAsync(d => d.Id == documentId && d.TenantId == tenantId)
            ?? throw new NotFoundException($"Document for the given tenantId (${tenantId.ToString()}) and documentId (${documentId.ToString()})");

        return doc.ClientId;
    }

    public async Task<string> GetDocumentContentAsync(string tenantId, string documentId)
    {
        return await GetDocumentContentAsync(new Guid(tenantId), new Guid(documentId));
    }

    public async Task<string> GetDocumentContentAsync(Guid tenantId, Guid documentId)
    {
        var doc = await DocumentRepo.GetWhereAsync(d => d.Id == documentId && d.TenantId == tenantId)
            ?? throw new NotFoundException($"Document for the given tenantId (${tenantId.ToString()}) and documentId (${documentId.ToString()})");

        var projectDirectory = Directory.GetCurrentDirectory();

        var documentPath = projectDirectory + doc.URI;

        string jsonContents = File.ReadAllText(documentPath);

        return jsonContents;
    }

    public async Task<string> AnonymizeDocumentContentBasedOnConfiguration(string content, string productCode)
    {
        var isValidJSON = content.IsValidJSON();

        if (!isValidJSON) throw new Exception("There is a problem with the document.");

        var fieldConfigurations = await ProductService.GetProductFieldConfigurations(productCode);

        foreach (var field in fieldConfigurations)
        {
            string pattern = $"(\"{field.Key}\":\\s*)(\"[^\"]*\"|\"?-?\\d+(\\.\\d+)?\"?)(\\s*)";

            string replacement = $"\"{field.Key}\": \"{field.Value.ToString().AnonymizeByConfig(field.Value)}\"";

            content = Regex.Replace(content, pattern, replacement);
        }

        return content;
    }
}

