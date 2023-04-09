using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCorp.Domain.Models;
using TestCorp.Repository;
using TestCorp.Services.Interfaces;

namespace TestCorp.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyRepository companyRepository;
        private readonly EmployeeRepository employeeRepository;

        public CompanyService(CompanyRepository cmpRepository, EmployeeRepository emplRepository)
        {
            companyRepository = cmpRepository;
            employeeRepository = emplRepository;
        }

        public Task<Company?> CreateCompany(Company company, IEnumerable<Employee> employees)
        {
            throw new NotImplementedException();
        }

        public Task<Company?> DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Company?> UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
