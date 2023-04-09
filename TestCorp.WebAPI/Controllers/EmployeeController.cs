using Microsoft.AspNetCore.Mvc;
using TestCorp.Core.Api;
using TestCorp.Services.Interfaces;
using TestCorp.WebAPI.Models;

namespace TestCorp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService emplService)
        {
            employeeService= emplService;
        }

        [HttpPost]
        [Route("employees")]
        public async Task<ApiResponseBase> CreateEmployee([FromBody] EmployeeDTO newEmployee)
        {
            // validacija
            // kreiranje
            // logovanje
            return null;
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
