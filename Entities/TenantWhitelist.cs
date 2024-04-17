namespace Entities;

public class TenantWhitelist : ITenantWhitelist
{
    public int Id { get; set; }
    public int TenantId { get; set; }
}
