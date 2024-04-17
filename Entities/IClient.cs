namespace Entities;

public interface IClient : IEntity
{
    string VAT { get; set; }
    CompanyType CompanyType { get; set; }
    string DocumentId { get; set; }
    int RegisterNumber { get; set; }
    int TenantId { get; set; }
}
