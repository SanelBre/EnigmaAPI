namespace EnigmaAPI.Entities;

public class Client : IClient
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public string VAT { get; set; }
}
