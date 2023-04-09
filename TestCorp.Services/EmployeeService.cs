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
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly CompanyRepository companyRepository;

        public EmployeeService(EmployeeRepository emplRepository, CompanyRepository cmpRepository) 
        {
            employeeRepository= emplRepository;
            companyRepository = cmpRepository;
        }

        public Task<Employee?> CreateEmployee(Employee employee, IEnumerable<int> companyIds)
        {
            return null;
        }

        public Task<Employee?> DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
