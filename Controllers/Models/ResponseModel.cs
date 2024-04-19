using EnigmaAPI.Entities;

namespace EnigmaAPI.API;

public class ResponseModel
{
    public string Data { get; set; }
    public CompanyModel Company { get; set; }
}

public class CompanyModel
{
    public int RegistrationNumber { get; set; }
    public string CompanyType { get; set; }
}

