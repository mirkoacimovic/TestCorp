using Microsoft.AspNetCore.Mvc;

namespace TestCorp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
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
