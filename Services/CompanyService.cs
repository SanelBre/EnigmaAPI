using EnigmaAPI.DataAccess;
using EnigmaAPI.Entities;
using EnigmaAPI.Utils.Exceptions;

namespace EnigmaAPI.Services;

public class CompanyService : ICompanyService
{
    private IRepository<ICompany> CompanyRepo;

    public CompanyService(IRepository<ICompany> company)
    {
        CompanyRepo = company;
    }

    public async Task<ICompany> GetCompanyByVAT(string VAT)
    {
        var company = await CompanyRepo.GetWhereAsync(c => c.VAT == VAT)
            ?? throw new NotFoundException($"Did not find Company with the provided VAT (${VAT})");

        return company;
    }

}

