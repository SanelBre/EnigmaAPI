namespace EnigmaAPI.Entities;

public interface IClient : IEntity
{
    Guid TenantId { get; set; }
    string VAT { get; set; }
}
