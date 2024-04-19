namespace EnigmaAPI.Entities;

public enum FieldVisibilityValues
{
    Shown,
    Hashed,
    Masked
}

public class ProductConfiguration : IProductConfiguration
{
    public Dictionary<string, FieldVisibilityValues> FieldVisibilities { get; set; } = new Dictionary<string, FieldVisibilityValues>();
}

public class Product : IProduct
{
    public Guid Id { get; set; }
    public string ProductCode { get; set; }
    public IProductConfiguration ProductConfiguration { get; set; } = new ProductConfiguration();
}
