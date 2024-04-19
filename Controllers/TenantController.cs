using Microsoft.AspNetCore.Mvc;
using EnigmaAPI.Services;

namespace EnigmaAPI.API;

[ApiController]
[Route("[controller]")]
public class TenantController : ControllerBase
{
    private readonly ITenantService TenantService;


    public TenantController(ITenantService tenantService)
    {
        TenantService = tenantService;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var res = await TenantService.ListAllAsync();

        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTenant(string id)
    {
        var res = await TenantService.GetTenantAsync(id);

        return Ok(res);
    }
}
