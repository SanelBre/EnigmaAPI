namespace EnigmaAPI.Entities;

public interface IProduct : IEntity
{
    string ProductCode { get; set; }
    string[] FieldsToHide { get; set; }
    IProductConfiguration ProductConfiguration { get; set; }
}

public interface IProductConfiguration
{
    Dictionary<string, FieldVisibilityValues> FieldVisibilities { get; set; }
}

