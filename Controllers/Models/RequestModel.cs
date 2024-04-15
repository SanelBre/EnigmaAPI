namespace API;

public class RequestModel
{
    public string ProductCode { get; set; }
    public Guid TenantId { get; set; }
    public Guid DocumentId { get; set; }
}
