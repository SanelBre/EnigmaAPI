using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API;

[ApiController]
[Route("[controller]")]
public class DocumentController : ControllerBase
{

    [HttpPost("anonymize")]
    public IActionResult Anonymize([FromBody]RequestModel request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

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
