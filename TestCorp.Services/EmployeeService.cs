using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestCorp.Domain.Data;
using TestCorp.Domain.Models;
using TestCorp.Repository;
using TestCorp.Services.Interfaces;

namespace TestCorp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Test4CreateDbContext db;
        private readonly EmployeeRepository employeeRepository;
        private readonly CompanyRepository companyRepository;
        private readonly IValidationService validationService;

        public EmployeeService(Test4CreateDbContext context, EmployeeRepository emplRepository, CompanyRepository cmpRepository, IValidationService validation) 
        {
            employeeRepository= emplRepository;
            companyRepository = cmpRepository;
            validationService = validation;
            db = context;
        }

        public async Task<Employee?> CreateEmployee(Employee employee, IEnumerable<int> companyIds)
        {
            if (db.Employees.Where(e => e.Email == employee.Email).FirstOrDefault() != null) return null; // employee already exists

            var companyEmployees = (from empl in db.Employees
                                    join emplCmp in db.CompanyEmployees
                                    on empl.Id equals emplCmp.EmployeeId
                                    select new CompanyEmployee
                                    {
                                        CompanyId = emplCmp.CompanyId,
                                        EmployeeId = emplCmp.EmployeeId,
                                        Employee = emplCmp.Employee
                                    }).Select(e => e).ToList();

            // creates new employee
            var newEmployee = await employeeRepository.CreateAsync(employee);

            if (newEmployee == null) return employee;

            foreach (var companyId in companyIds)
            {
                // check if employee already exists for company
                var companyEmployee = companyEmployees.Where(ce => ce.EmployeeId == employee.Id && ce.CompanyId == companyId).FirstOrDefault();

                if (companyEmployee != null || companyEmployees.Where(cx => cx.Employee?.Title == employee.Title).FirstOrDefault() == null) continue;

                // associate employee and company
                var comp = await companyRepository.GetByIdAsync(companyId);
                if (comp != null)
                {
                    await db.CompanyEmployees.AddAsync(new CompanyEmployee { EmployeeId = newEmployee.Id, Employee = newEmployee, CompanyId = companyId, Company = comp });
                    await db.SaveChangesAsync();
                }
            }
            
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
