namespace Services;

public interface IProductService
{
    public Task<bool> IsProductSupportedAsync(string productCode);
}
