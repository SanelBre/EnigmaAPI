namespace EnigmaAPI.Entities;

public class Tenant : ITenant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
