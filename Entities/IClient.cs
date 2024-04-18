namespace Entities;

public interface IClient : IEntity
{
    int TenantId { get; set; }
    string VAT { get; set; }
    string DocumentId { get; set; }
}
