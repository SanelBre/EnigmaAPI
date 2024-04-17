using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API;

public class RequestModel
{
    [Required]
    [JsonPropertyName("productCode")]
    public string ProductCode { get; set; }

    [Required]
    [JsonPropertyName("tenantId")]
    public int? TenantId { get; set; }

    [Required]
    public int? DocumentId { get; set; }
}
