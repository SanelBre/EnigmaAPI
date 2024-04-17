namespace Entities;

public interface ITenantWhitelist : IEntity
{
    public int TenantId { get; set; }
}

