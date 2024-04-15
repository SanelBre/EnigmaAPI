namespace API;

public class ResponseModel
{
    public string Data { get; set; }
    public CompanyModel Company { get; set; }
}

public class CompanyModel
{
    public string RegistrationNumber { get; set; }
    public CompanyType CompanyType { get; set; }
}

public enum CompanyType
{
    Small,
    Medium,
    Large
}
