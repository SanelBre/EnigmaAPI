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

    public DocumentController(IProductService productService)
    {
        ProductService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> Anonymize([FromBody] RequestModel request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var isSupported = await ProductService.IsProductSupportedAsync(request.ProductCode);

        if (!isSupported) throw new ForbiddenException("Access is forbidden");

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
