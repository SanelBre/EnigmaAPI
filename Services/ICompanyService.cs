using Entities;

namespace EnigmaAPI.Services;

public interface ICompanyService
{
    public Task<ICompany> GetCompanyByVAT(string VAT);
}

