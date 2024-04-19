namespace EnigmaAPI.Entities;


public class Document : IDocument
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid ClientId { get; set; }
    public string URI { get; set; }
}
