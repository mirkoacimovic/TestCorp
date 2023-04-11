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
    public class CompanyController : ControllerBase
    {
        private readonly Mapper mapper;
        private readonly ICompanyService companyService;

        public CompanyController(Mapper map, ICompanyService compsrv)
        {
            companyService = compsrv;
            mapper = map;
        }

        [HttpPost]
        [Route("employees")]
        public async Task<ApiResponseBase> CreateCompany([FromBody] CompanyDTO newCompany)
        {
            try
            {
                var company = mapper.Map<Company>(newCompany);


                return await Task.FromResult(new ApiResponseBase
                {
                    Status = 200,
                    ErrorMessage = "Company has been created.",
                    Data = newCompany
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
