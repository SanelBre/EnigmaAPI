namespace Entities;

public class Client : IClient
{
    public int Id { get; set; }
    public string VAT { get; set; }
    public CompanyType CompanyType { get; set; }
    public string DocumentId { get; set; }
    public int RegisterNumber { get; set; }
    public int TenantId { get; set; }
}

public enum CompanyType
{
    Small,
    Medium,
    Large
}
