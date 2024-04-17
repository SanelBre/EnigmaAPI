namespace Entities;

public class Tenant : ITenant
{
    public int Id { get; set; }
    public bool IsWhitelisted { get; set; }
}
