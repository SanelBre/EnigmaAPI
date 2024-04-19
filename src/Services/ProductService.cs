using EnigmaAPI.DataAccess;
using EnigmaAPI.Entities;
using EnigmaAPI.Utils.Exceptions;

namespace EnigmaAPI.Services;

public class ProductService : IProductService
{

    private IRepository<IProduct> ProductRepo;

    public ProductService(IRepository<IProduct> product)
    {
        ProductRepo = product;
    }

    public async Task<List<IProduct>> ListAllAsync()
    {
        var res = await ProductRepo.GetAllWhereAsync(p => p != null);

        return res?.ToList() ?? [];
    }

    public async Task<IProduct> GetByProductCodeAsync(string productCode)
    {
        var product = await ProductRepo.GetWhereAsync(p => p.ProductCode == productCode);

        return product;
    }

    public async Task<bool> IsProductSupportedAsync(string productCode)
    {
        var product = await GetByProductCodeAsync(productCode);

        return product != null;
    }

    public async Task<Dictionary<string, FieldVisibilityValues>> GetProductFieldConfigurations(string productCode)
    {
        var product = await ProductRepo.GetWhereAsync(p => p.ProductCode == productCode)
            ?? throw new NotFoundException($"The required product ({productCode}) was not found.");

        return product.ProductConfiguration.FieldVisibilities;
    }
}
