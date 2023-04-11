using TestCorp.Domain.Models;

namespace TestCorp.WebAPI.Models
{
    public class CompanyDTO
    {
        public string? Name { get; set; }
        public IEnumerable<object>? Employees { get; set; }
    }
}
