namespace Entities;

public interface ICompany : IEntity
{
    string VAT { get; set; }
    int RegisterNumber { get; set; }
    CompanyType CompanyType { get; set; }
}
