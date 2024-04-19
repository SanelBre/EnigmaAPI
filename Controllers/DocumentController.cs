using Microsoft.AspNetCore.Mvc;
using EnigmaAPI.Entities;
using EnigmaAPI.Services;
using EnigmaAPI.Utils.Exceptions;

namespace EnigmaAPI.API;

[ApiController]
[Route("[controller]")]
public class DocumentController : ControllerBase
{
    private readonly IProductService ProductService;
    private readonly IDocumentService DocumentService;
    private readonly IClientService ClientService;
    private readonly ITenantService TenantService;
    private readonly ICompanyService CompanyService;


    public DocumentController(
        IProductService productService,
        IDocumentService documentService,
        IClientService clientService,
        ICompanyService companyService,
        ITenantService tenantService)
    {
        ProductService = productService;
        DocumentService = documentService;
        ClientService = clientService;
        TenantService = tenantService;
        CompanyService = companyService;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var res = await DocumentService.ListAllAsync();

        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDocument(string id)
    {
        var res = await TenantService.GetTenantAsync(id);

        return Ok(res);
    }

    [HttpPost("anonymize")]
    public async Task<IActionResult> Anonymize([FromBody] RequestModel request)
    {
        var isSupported = await ProductService.IsProductSupportedAsync(request.ProductCode);

        if (!isSupported)
            throw new ForbiddenException("Access is forbidden");

        var tenantData = await TenantService.GetWhitelistedTenantAsync(request.TenantId);

        var clientId = await DocumentService.GetClientIdAsync(tenantData.Id.ToString(), request.DocumentId);

        var clientData = await ClientService.GetWhitelistedClientDataByIdAsync(clientId);

        var company = await CompanyService.GetCompanyByVAT(clientData.VAT);

        if (company.CompanyType == CompanyType.Small)
            throw new ForbiddenException("Small companies not permitted");

        var doc = await DocumentService.GetDocumentContentAsync(tenantData.Id.ToString(), request.DocumentId);

        var anonDoc = await DocumentService.AnonymizeDocumentContentBasedOnConfiguration(doc, request.ProductCode);

        var response = new ResponseModel
        {
            Data = anonDoc,
            Company = new CompanyModel
            {
                RegistrationNumber = company.RegisterNumber,
                CompanyType = company.CompanyType.ToString()
            }
        };

        return Ok(response);
    }
}
