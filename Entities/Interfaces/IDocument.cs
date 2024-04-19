namespace EnigmaAPI.Entities;

public interface IDocument : IEntity {
    public Guid TenantId { get; set; }
    public Guid ClientId { get; set; }
}
