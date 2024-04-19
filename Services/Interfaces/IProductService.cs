using EnigmaAPI.Entities;

namespace EnigmaAPI.Services;

public interface IProductService
{
    public Task<List<IProduct>> ListAllAsync();
    public Task<IProduct> GetByProductCodeAsync(string productCode);
    public Task<bool> IsProductSupportedAsync(string productCode);
    public Task<Dictionary<string, FieldVisibilityValues>> GetProductFieldConfigurations(string productCode);
}
