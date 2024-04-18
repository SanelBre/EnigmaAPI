namespace Entities;

public class Client : IClient
{
    public int Id { get; set; }
    public int TenantId { get; set; }
    public string VAT { get; set; }
    public string DocumentId { get; set; }
}
