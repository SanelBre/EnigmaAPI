namespace EnigmaAPI.Entities;

public class Company : ICompany
{
    public Guid Id { get; set; }
    public string VAT { get; set; }
    public int RegisterNumber { get; set; }
    public CompanyType CompanyType { get; set; }
}

public enum CompanyType
{
    Small,
    Medium,
    Large
}
