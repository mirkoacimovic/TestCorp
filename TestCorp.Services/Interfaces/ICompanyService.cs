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
        Task<Company> GetAllCompanies();
        Task<Company> GetCompanyById(int id);
        Task<Company?> CreateCompany();
        Task<Company?> UpdateCompany();
        Task<Company?> DeleteCompany();
    }
}
