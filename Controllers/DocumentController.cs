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
    

    public DocumentController(
        IProductService productService,
        IClientService clientService)
    {
        ProductService = productService;
        ClientService = clientService;
    }

    [HttpPost]
    public async Task<IActionResult> Anonymize([FromBody] RequestModel request)
    {
        var isSupported = await ProductService.IsProductSupportedAsync(request.ProductCode);

        if (!isSupported) throw new ForbiddenException("Access is forbidden");

        var clientData = await ClientService.GetWhitelistedClientDataAsync((int)request.TenantId, request.DocumentId);

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
