using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using TestCorp.Core.Api;
using TestCorp.Domain.Models;
using TestCorp.Services.Interfaces;
using TestCorp.WebAPI.Models;

namespace TestCorp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private IMapper Mapper { get; }
        private readonly ICompanyService companyService;

        public CompanyController(IMapper map, ICompanyService compsrv)
        {
            companyService = compsrv;
            Mapper = map;
        }

        [HttpPost]
        [Route("companies")]
        public async Task<ApiResponseBase> CreateCompany([FromBody] CompanyDTO newCompany)
        {
            try
            {
                var company = Mapper.Map<Company>(newCompany);
                company.CreatedAt = DateTime.Now.ToUniversalTime();
                var employees = Mapper.Map<IEnumerable<string>>(newCompany.Employees);
                await companyService.CreateCompany(company, employees);

                return await Task.FromResult(new ApiResponseBase
                {
                    Status = 200,
                    ErrorMessage = "Company has been created.",
                    Data = company
                });
            }
            catch(Exception ex)
            {
                return await Task.FromResult(new ApiResponseBase
                {
                    Status = 500,
                    ErrorMessage = ex.Message,
                    Data = newCompany
                });
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
