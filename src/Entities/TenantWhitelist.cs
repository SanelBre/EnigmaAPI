namespace EnigmaAPI.Entities;

public class TenantWhitelist : ITenantWhitelist
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
}
