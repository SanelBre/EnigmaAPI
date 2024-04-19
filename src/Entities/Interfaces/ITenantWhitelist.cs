namespace EnigmaAPI.Entities;

public interface ITenantWhitelist : IEntity
{
    public Guid TenantId { get; set; }
}

