using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EnigmaAPI.API;

public class RequestModel
{
    [Required]
    [JsonPropertyName("productCode")]
    public string ProductCode { get; set; }

    [Required]
    [JsonPropertyName("tenantId")]
    public string TenantId { get; set; }

    [Required]
    [JsonPropertyName("documentId")]
    public string DocumentId { get; set; }
}
