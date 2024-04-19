using Microsoft.AspNetCore.Mvc;
using EnigmaAPI.Services;

namespace EnigmaAPI.API;

[ApiController]
[Route("[controller]")]
public class Product : ControllerBase
{
    private readonly IProductService ProductService;


    public Product(IProductService productService)
    {
        ProductService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var res = await ProductService.ListAllAsync();

        return Ok(res);
    }

    [HttpGet("{productCode}")]
    public async Task<IActionResult> GetTenant(string productCode)
    {
        var res = await ProductService.GetByProductCodeAsync(productCode);

        return Ok(res);
    }
}
