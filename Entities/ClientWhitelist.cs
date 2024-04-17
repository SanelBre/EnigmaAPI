namespace Entities;

public class ClientWhitelist : IClientWhitelist
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int TenantId { get; set; }
}
