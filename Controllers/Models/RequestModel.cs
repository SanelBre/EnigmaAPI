using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EnigmaAPI.API;

public class RequestModel
{
    [Required]
    [JsonPropertyName("productCode")]
    public string ProductCode { get; set; }

    [Required]
    [RegularExpression(@"^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$", ErrorMessage = "Invalid GUID format.")]
    [JsonPropertyName("tenantId")]
    public string TenantId { get; set; }

    [Required]
    [RegularExpression(@"^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$", ErrorMessage = "Invalid GUID format.")]
    [JsonPropertyName("documentId")]
    public string DocumentId { get; set; }
}
