using WebApi.Dto;
using WebApi.Entities;

namespace WebApi.Contracts
{
    public interface ICompanyRepository
    {

        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompany(int id);
        Task<Company> CreateCompany(CompanyForCreationDto company);
        Task UpdateCompany(int id, CompanyForUpdateDto company);
        Task DeleteCompany(int id);
        Task<Company> GetCompanyByEmployeeId(int id);
        Task<Company> GetCompanyEmployeesMultipleResults(int id);
        Task<List<Company>> GetCompaniesEmployeesMultipleMapping();
        Task CreateMultipleCompanies(List<CompanyForCreationDto> companies);

    }
}
