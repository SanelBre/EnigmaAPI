using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
using Utils.Exceptions;
using EnigmaAPI.Services;

namespace API;

[ApiController]
[Route("[controller]")]
public class DocumentController : ControllerBase
{
    private readonly IProductService ProductService;
    private readonly IClientService ClientService;
    private readonly ITenantService TenantService;
    private readonly ICompanyService CompanyService;


    public DocumentController(
        IProductService productService,
        IClientService clientService,
        ICompanyService companyService,
        ITenantService tenantService)
    {
        ProductService = productService;
        ClientService = clientService;
        TenantService = tenantService;
        CompanyService = companyService;
    }

    [HttpPost]
    public async Task<IActionResult> Anonymize([FromBody] RequestModel request)
    {
        var isSupported = await ProductService.IsProductSupportedAsync(request.ProductCode);

        if (!isSupported) throw new ForbiddenException("Access is forbidden");

        var tenantData = await TenantService.GetWhitelistedTenantAsync((int)request.TenantId);

        var clientData = await ClientService.GetWhitelistedClientDataAsync(tenantData.Id, request.DocumentId);

        var company = await CompanyService.GetCompanyByVAT(clientData.VAT);

        if (company.CompanyType == CompanyType.Small) throw new ForbiddenException("Small companies not permitted");

        var response = new ResponseModel
        {
            Data = "serialized and anonymized JSON",
            Company = new CompanyModel
            {
                RegistrationNumber = company.RegisterNumber,
                CompanyType = company.CompanyType.ToString()
            }
        };

        return Ok(response);
    }
}
