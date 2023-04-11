using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCorp.Domain.Models;

namespace TestCorp.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompanyById(int id);
        Task<Company?> CreateCompany(Company company, IEnumerable<string> employees);
        Task<Company?> UpdateCompany(Company company);
        Task<Company?> DeleteCompany(int id);
    }
}
