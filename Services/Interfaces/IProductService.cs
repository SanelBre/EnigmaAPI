using EnigmaAPI.Entities;

namespace EnigmaAPI.Services;

public interface IProductService
{
    public Task<bool> IsProductSupportedAsync(string productCode);
    public Task<Dictionary<string, FieldVisibilityValues>> GetProductFieldConfigurations(string productCode);
}
