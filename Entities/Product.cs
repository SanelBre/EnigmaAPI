namespace EnigmaAPI.Entities;

public class Product : IProduct
{
    public Guid Id { get; set; }
    public string ProductCode { get; set; }
}
