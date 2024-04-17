using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
using Utils.Exceptions;

namespace API;

[ApiController]
[Route("[controller]")]
public class DocumentController : ControllerBase
{
    private readonly IProductService ProductService;
    private readonly IClientService ClientService;
    private readonly ITenantService TenantService;


    public DocumentController(
        IProductService productService,
        IClientService clientService,
        ITenantService tenantService)
    {
        ProductService = productService;
        ClientService = clientService;
        TenantService = tenantService;
    }

    [HttpPost]
    public async Task<IActionResult> Anonymize([FromBody] RequestModel request)
    {
        var isSupported = await ProductService.IsProductSupportedAsync(request.ProductCode);

        if (!isSupported) throw new ForbiddenException("Access is forbidden");

        var tenantData = await TenantService.GetWhitelistedTenantAsync((int)request.TenantId);

        var clientData = await ClientService.GetWhitelistedClientDataAsync(tenantData.Id, request.DocumentId);

        var response = new ResponseModel
        {
            Data = "serialized and anonymized JSON",
            Company = new CompanyModel
            {
                RegistrationNumber = "string",
                CompanyType = CompanyType.Small
            }
        };

        return Ok(response);
    }
}
