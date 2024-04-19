namespace EnigmaAPI.Entities;

public class ClientWhitelist : IClientWhitelist
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
}
