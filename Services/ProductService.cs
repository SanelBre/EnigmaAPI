using DataAccess;
using Entities;

namespace Services;

public class ProductService : IProductService
{

    private IRepository<IProduct> ProductRepo;

    public ProductService(IRepository<IProduct> product)
    {
        ProductRepo = product;
    }

    public async Task<bool> IsProductSupportedAsync(string productCode)
    {
        var product = await ProductRepo.GetWhereAsync(p => p.ProductCode == productCode);

        return product != null;
    }
}
