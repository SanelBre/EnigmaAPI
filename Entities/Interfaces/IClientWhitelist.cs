namespace EnigmaAPI.Entities;

public interface IClientWhitelist : IEntity
{
    public Guid ClientId { get; set; }
}
