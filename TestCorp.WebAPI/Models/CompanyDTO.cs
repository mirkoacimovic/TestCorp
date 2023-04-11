using TestCorp.Domain.Models;

namespace TestCorp.WebAPI.Models
{
    public class CompanyDTO
    {
        public string? Name { get; set; }
        public Employee[]? Employees { get;}
    }
}
