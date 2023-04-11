using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestCorp.Core.Api;
using TestCorp.Domain.Models;
using TestCorp.Services.Interfaces;
using TestCorp.WebAPI.Models;

namespace TestCorp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IValidationService validationService;
        private IMapper Mapper { get; }

        public EmployeeController(IEmployeeService emplService, IValidationService validation, IMapper mapper)
        {
            employeeService= emplService;
            validationService  = validation;
            Mapper = mapper;
        }

        [HttpPost]
        [Route("employees")]
        public async Task<ApiResponseBase> CreateEmployee([FromBody] EmployeeDTO newEmployee)
        {
            try
            {
                var employee = Mapper.Map<Employee>(newEmployee);
                employee.CreatedAt = DateTime.Now.ToUniversalTime();
                await employeeService.CreateEmployee(employee, newEmployee.CompanyIds);

                return new ApiResponseBase
                {
                    Data = newEmployee,
                    Status = 200,
                    ErrorMessage = "Created employee."
                };
            }
            catch (Exception ex)
            {
                return new ApiResponseBase
                {
                    Data = newEmployee,
                    Status = 500,
                    ErrorMessage = ex.Message
                };
            }
        }

        // endpoint that tell user if API service is running
        [HttpGet]
        [Route("health")]
        public async Task<IEnumerable<string>> HealthCheck()
        {
            return await Task.FromResult(new List<string>()
            {
                "System is up and running.",
                "You are able to call other enpoints."
            }.AsEnumerable());
        }
    }
}
