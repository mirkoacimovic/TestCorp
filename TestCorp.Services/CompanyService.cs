using Microsoft.EntityFrameworkCore;
using System.Text.Json.Nodes;
using TestCorp.Domain.Data;
using TestCorp.Domain.Models;
using TestCorp.Repository;
using TestCorp.Services.Interfaces;

namespace TestCorp.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly Test4CreateDbContext db;
        private readonly CompanyRepository companyRepository;
        private readonly EmployeeRepository employeeRepository;
        private readonly ILog loggerService;

        public CompanyService(Test4CreateDbContext context, ILog logger, CompanyRepository cmpRepository, EmployeeRepository emplRepository)
        {
            companyRepository = cmpRepository;
            employeeRepository = emplRepository;
            db = context;
            loggerService = logger;
        }

        public async Task<Company?> CreateCompany(Company company, IEnumerable<string> employees)
        {
            try
            {
                var companies = await companyRepository.GetAllAsync();
                if (companies.Where(c => c.Name == company.Name).FirstOrDefault() != null) return null;
                company.Id = db.Companies.Count() + 1;
                var newCompany = await companyRepository.CreateAsync(company);

                // add employees
                foreach (var employee in employees)
                {
                    Employee? dbEmployee = null;
                    if (int.TryParse(employee, out int id))
                    {
                        if (id > 0 && db.CompanyEmployees.Where(ce => ce.Employee.Id == id && ce.CompanyId == newCompany.Id).FirstOrDefault() != null) continue;
                        dbEmployee = await employeeRepository.GetByIdAsync(id);
                    }
                    else if (employee is string)
                    {
                        var email = Convert.ToString((string)employee);
                        if (!String.IsNullOrEmpty(email))
                        {
                            dbEmployee = await db.Employees.Where(e => e.Email == email).FirstOrDefaultAsync();
                        }
                    } 

                    if (dbEmployee != null && newCompany != null)
                    {
                        await db.CompanyEmployees.AddAsync(new CompanyEmployee { EmployeeId = dbEmployee.Id, CompanyId = newCompany.Id, Company = newCompany, Employee = dbEmployee });
                        await db.SaveChangesAsync();
                    }
                }

                await loggerService.Log(new SystemLog
                {
                    Event = Domain.Models.Enums.EventType.CREATE,
                    ResourceType = Domain.Models.Enums.ResourceType.Company,
                    Comment = $"New ${newCompany.Name} was created.",
                    CreatedAt = DateTime.Now.ToUniversalTime(),
                });

                return newCompany;
            }
            catch (Exception ex)
            {
                await loggerService.Log(new SystemLog
                {
                    Event = Domain.Models.Enums.EventType.CREATE,
                    ResourceType = Domain.Models.Enums.ResourceType.Company,
                    Comment = $"Eroor while creating company. {ex.Message}",
                    CreatedAt = DateTime.Now.ToUniversalTime(),
                });
                return null;
            }
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
