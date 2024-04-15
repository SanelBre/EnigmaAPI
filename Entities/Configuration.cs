namespace Entities;

public class Configuration
{
    public string ProductId { get; set; }
    public string FieldName { get; set; }
    public AnonymizationType AnonymizationType { get; set; }
}

public enum AnonymizationType
{
    Hash,
    LeaveUnchanged
}
