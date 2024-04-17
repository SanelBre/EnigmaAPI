namespace Entities;

public interface IClientWhitelist : IEntity
{
    public int ClientId { get; set; }
    public int TenantId { get; set; }
}
