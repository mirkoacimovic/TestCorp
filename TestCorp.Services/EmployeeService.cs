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
        private readonly ILog loggerService;
        private readonly CompanyRepository companyRepository;
        private readonly IValidationService validationService;

        public EmployeeService(Test4CreateDbContext context, ILog logger, EmployeeRepository emplRepository, CompanyRepository cmpRepository, IValidationService validation) 
        {
            employeeRepository= emplRepository;
            companyRepository = cmpRepository;
            validationService = validation;
            db = context;
            loggerService = logger;
        }

        public async Task<Employee?> CreateEmployee(Employee employee, IEnumerable<int> companyIds)
        {
            if (db.Employees.Where(e => e.Email == employee.Email).FirstOrDefault() != null) return null; // employee already exists

            try
            {
                Employee? newEmployee = null; 

                foreach (var companyId in companyIds) 
                {
                    var employeeCompany = from emp in db.Employees
                                          join empCmp in db.CompanyEmployees
                                          on emp.Id equals empCmp.EmployeeId
                                          where empCmp.CompanyId == companyId && employee.Id == emp.Id && emp.Title == employee.Title
                                          select emp;
                    
                    if (employeeCompany.Count() > 0) continue;

                    // creates new employee
                    employee.Id = db.Employees.Count() + 1;
                    newEmployee = await employeeRepository.CreateAsync(employee);
                    await db.CompanyEmployees.AddAsync(new CompanyEmployee { EmployeeId = employee.Id, CompanyId= companyId });
                    await db.SaveChangesAsync();
                    await loggerService.Log(new SystemLog
                    {
                        ResourceType = Domain.Models.Enums.ResourceType.Employee,
                        Event = Domain.Models.Enums.EventType.CREATE,
                        Comment = $"New employee {newEmployee.Email} was created.",
                        CreatedAt = DateTime.Now.ToUniversalTime(),
                        Changeset = $"{newEmployee.Id}, {newEmployee.Email}, {newEmployee.Title}, {newEmployee.CreatedAt}"
                    });
                }

                return newEmployee;
            }
            catch(Exception ex)
            {
                await loggerService.Log(new SystemLog
                {
                    ResourceType = Domain.Models.Enums.ResourceType.Employee,
                    Event = Domain.Models.Enums.EventType.CREATE,
                    Comment = $"Error while creating employee. {ex.Message}",
                    CreatedAt = DateTime.Now.ToUniversalTime(),
                });
                return null;
            }
            
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
